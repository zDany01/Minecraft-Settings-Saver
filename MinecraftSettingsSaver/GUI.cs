using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace MinecraftSettingsSaver
{
    public partial class GUI : Form
    {
        private const string APP_NAME = "Minecraft Settings Saver";
        private static readonly string MinecraftPath = Environment.GetEnvironmentVariable("appdata") + "\\.minecraft\\";
        private readonly string ApplicationDataDir = MinecraftPath + "MSavedProfiles\\";
        private bool allowOptifineSettings;
        public GUI()
        {
            InitializeComponent();
            this.Load += GUI_Load;
            this.Icon = Properties.Resources.icon;
            profilesListBox.Font = new Font(FontFamily.GenericMonospace, profilesListBox.Font.Size, FontStyle.Bold);
            #region "Event Handler"
            SaveProfileBtn.Click += SaveProfileBtn_Click;
            deleteAllProfileBtn.Click += DeleteAllProfileBtn_Click;
            reloadToolStripMenuItem.Click += RefreshProfilesList;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            LoadSettingsBtn.Click += LoadSettingsBtn_Click;
            profilesListBox.SelectedValueChanged += ProfilesListBox_SelectedValueChanged;
            optifineSettingsCBox.CheckedChanged += OptifineSettingsCBox_CheckedChanged;
            ExportBtn.Click += ExportBtn_Click;
            ImportBtn.Click += ImportBtn_Click;
            importProfilesDialog.FileOk += OpenFileDialog1_FileOk;
            saveProfilesDialog.FileOk += SaveFileDialog1_FileOk;
            #endregion
        }

        private void CheckOptifine()
        {
            if (File.Exists(MinecraftPath + "optionsof.txt"))
            {
                if (!File.Exists(MinecraftPath + "optionsshaders.txt")) File.Create(MinecraftPath + "optionsshaders.txt").Close();
                optifineSettingsCBox.Cursor = Cursors.Default;
                optifineTooltip.RemoveAll();
                allowOptifineSettings = true;
            }
            else
            {
                optifineSettingsCBox.Cursor = Cursors.No;
                optifineTooltip.SetToolTip(optifineSettingsCBox, "The program can't find optifine configuration file.");
                allowOptifineSettings = false;
            }
        }

        private string RemoveFinalSpaces(string listBoxItem)
        {
            while (listBoxItem.EndsWith(" ")) listBoxItem = listBoxItem.Remove(listBoxItem.Length - 1, 1);
            return listBoxItem;
        }

        private void RefreshProfilesList(object sender = null, EventArgs e = null)
        {
            profilesListBox.Items.Clear();
            profilesListBox.Items.Add(string.Format("{0,-19} {1,-9} {2}", "Profile name", "MVersion", "Optifine"));

            foreach (string filename in Directory.GetFiles(ApplicationDataDir)) if (filename.EndsWith(".smc")) CheckIfValidProfile(filename);

            if (profilesListBox.Items.Count > 1)
            {
                profilesListBox.Enabled = true;
                ExportBtn.Enabled = true;
                deleteAllProfileBtn.Enabled = true;
            }
            else
            {
                profilesListBox.Enabled = false;
                ExportBtn.Enabled = false;
                LoadSettingsBtn.Enabled = false;
                deleteAllProfileBtn.Enabled = false;
            }

        }

        private void CheckIfValidProfile(string filepath)
        {
            using (ZipArchive zipArchive = ZipFile.OpenRead(filepath))
            {
                if (zipArchive.GetEntry("info") != null)
                {
                    string readedInfo = new StreamReader(zipArchive.GetEntry("info").Open()).ReadToEnd().Replace("\r", null); readedInfo = readedInfo.Remove(readedInfo.Length - 1, 1);
                    string[] zipInfo = readedInfo.Split('\n');
                    if (zipInfo.Length == 3)
                    {
                        string profileName = zipInfo[0];
                        string minecraftVersion = zipInfo[1];
                        bool.TryParse(zipInfo[2], out bool optifineCheck);
                        string hasOptifineSettings = optifineCheck ? "✓" : "✗";
                        profilesListBox.Items.Add(string.Format($"{{0, -22}}{{1,-15}}{{2}}", profileName, minecraftVersion, hasOptifineSettings));
#if DEBUG
                        Debug.WriteLine($"Name: {profileName}\nVersion: {minecraftVersion}\nInclude Optifine settings: {hasOptifineSettings}\n");
#endif
                        return;
                    }
                }
            }
#if DEBUG
            Debug.WriteLine($"File \"{filepath}\" has been deleted because it wasn't a valid file");
#endif
            File.Delete(filepath);
        }

        private void ImportBtn_Click(object sender, EventArgs e) => importProfilesDialog.ShowDialog();

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (ZipArchive archive = ZipFile.OpenRead(importProfilesDialog.FileName))
            {
                if (archive.GetEntry("info") != null && new StreamReader(archive.GetEntry("info").Open()).ReadToEnd().GetHashCode() == 1446666046)
                {
                    int profileCount = archive.Entries.Count - 1;
                    if (MessageBox.Show($"Total profiles found: {profileCount}.\nNOTE: If a profile already exists it will be overwritten, continue?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                    foreach (ZipArchiveEntry entry in archive.Entries) if (entry.Name != "info") entry.ExtractToFile(ApplicationDataDir + entry.Name, true);
                    MessageBox.Show($"Successfully imported {profileCount} profiles.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This is not a valid profile export file.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshProfilesList();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            if (File.Exists(saveProfilesDialog.FileName)) File.Delete(saveProfilesDialog.FileName);
            ZipFile.CreateFromDirectory(ApplicationDataDir, saveProfilesDialog.FileName);
            using (ZipArchive archive = ZipFile.Open(saveProfilesDialog.FileName, ZipArchiveMode.Update))
            {
                using (StreamWriter writer = new StreamWriter(archive.CreateEntry("info").Open()))
                {
                    writer.Write(
@"#################################################################################################################################
This is a simple file to let the program understand that the package to import was generated by the app itself.                 |
if you wanna import manually the profiles, copy all files(except this one) to the MSavedProfiles folder in your .minecraft path.|
#################################################################################################################################");
                }
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e) => saveProfilesDialog.ShowDialog();

        private void OptifineSettingsCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowOptifineSettings) optifineSettingsCBox.Checked = false;
        }

        private void ProfilesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSettingsBtn.Enabled = profilesListBox.SelectedItems.Count > 0;
        }

        private void LoadSettingsBtn_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("javaw").Length > 0 && MessageBox.Show("Java is running, make sure that minecraft is not open when applying profiles!\nDo you want to continue anyway?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            if (profilesListBox.SelectedIndex > 0)
            {
                string profileFilePath = ApplicationDataDir + RemoveFinalSpaces(profilesListBox.SelectedItem.ToString().Substring(0, profilesListBox.SelectedItem.ToString().LastIndexOf(".") - 2)) + ".smc";
                if (File.Exists(profileFilePath)) //to remove in the future if implementing FileSystemWatcher
                {
                    using (ZipArchive settingsFile = ZipFile.Open(profileFilePath, ZipArchiveMode.Read))
                    {
                        if (MessageBox.Show("This will overwrite your current settings!\nDo you wish to continue?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                        try
                        {
                            settingsFile.GetEntry("options.txt").ExtractToFile(MinecraftPath + "options.txt", true);
                            string readedInfo = new StreamReader(settingsFile.GetEntry("info").Open()).ReadToEnd().Replace("\r", null); readedInfo = readedInfo.Remove(readedInfo.Length - 1, 1);
                            bool.TryParse(readedInfo.Split('\n')[2], out bool hasOptifineSettings);
                            if (hasOptifineSettings)
                            {
                                settingsFile.GetEntry("optionsof.txt").ExtractToFile(MinecraftPath + "optionsof.txt", true);
                                settingsFile.GetEntry("optionsshaders.txt").ExtractToFile(MinecraftPath + "optionsshaders.txt", true);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("An error occurred while loading settings.\nMake sure that minecraft is closed.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        MessageBox.Show("Profile settings successfully applied", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CheckOptifine();
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profilesListBox.SelectedIndex > 0)
            {
                string filePath = ApplicationDataDir + profilesListBox.SelectedItem.ToString().Substring(0, profilesListBox.SelectedItem.ToString().LastIndexOf(".") - 2);
                filePath = RemoveFinalSpaces(filePath);
                File.Delete(filePath + ".smc");
                RefreshProfilesList();
            }
        }

        private void DeleteAllProfileBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Directory.Delete(ApplicationDataDir, true);
                Directory.CreateDirectory(ApplicationDataDir);
                RefreshProfilesList();
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("javaw").Length > 0) MessageBox.Show("Java is running, make sure that Minecraft is closed before using the application!", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!Directory.Exists(ApplicationDataDir)) Directory.CreateDirectory(ApplicationDataDir);
            minecraftVersionCBox.SelectedIndex = 0;
            CheckOptifine();
            RefreshProfilesList();
        }

        private void SaveProfileBtn_Click(object sender, EventArgs e)
        {
            #region "CheckTextBoxText"
            if (string.IsNullOrEmpty(nomeProfiloTxbx.Text))
            {
                MessageBox.Show("Insert a valid name for the profile.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (char item in "+ùàòè*éç°§^?'.\\/#%${}<>$!£ì;,[]:@\"")
            {
                if (nomeProfiloTxbx.Text.Contains(item))
                {
                    MessageBox.Show("Insert a valid name for the profile.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            nomeProfiloTxbx.Text = RemoveFinalSpaces(nomeProfiloTxbx.Text);
            #endregion

            if (!File.Exists(MinecraftPath + "options.txt"))
            {
                MessageBox.Show("There is no minecraft settings file, make sure that you have opened minecraft once.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = ApplicationDataDir + nomeProfiloTxbx.Text + ".smc";
            if (File.Exists(fileName) && MessageBox.Show("A profile with this name already exists.\nDo you want to overwrite it?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;



            using (ZipArchive archive = new ZipArchive(File.OpenWrite(fileName), ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(MinecraftPath + "options.txt", "options.txt");
                if (optifineSettingsCBox.Checked)
                {
                    archive.CreateEntryFromFile(MinecraftPath + "optionsof.txt", "optionsof.txt");
                    archive.CreateEntryFromFile(MinecraftPath + "optionsshaders.txt", "optionsshaders.txt");
                }
                using (StreamWriter writer = new StreamWriter(archive.CreateEntry("info").Open()))
                {
                    writer.WriteLine($"{nomeProfiloTxbx.Text}\n{minecraftVersionCBox.SelectedItem}\n{optifineSettingsCBox.Checked}");
                }
            }
            RefreshProfilesList();
        }
    }
}
