using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace MinecraftSettingsSaver
{
    public partial class GUI : Form
    {
        static string MinecraftPath = Environment.GetEnvironmentVariable("appdata") + "\\.minecraft\\";
        string ApplicationDataDir = MinecraftPath + "MSavedProfiles\\";
        bool allowOptifineSettings = false;
        public GUI()
        {
            InitializeComponent();
            #region "Event Handler"
            this.Load += GUI_Load;
            SaveSettingsBtn.Click += SaveSettingsBtn_Click;
            deleteAllProfileBtn.Click += DeleteAllProfileBtn_Click;
            reloadToolStripMenuItem.Click += RefreshSettingsList;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            LoadSettingsBtn.Click += LoadSettingsBtn_Click;
            profilesListBox.SelectedValueChanged += ProfilesListBox_SelectedValueChanged;
            optifineSettingsCBox.CheckedChanged += OptifineSettingsCBox_CheckedChanged;
            ExportBtn.Click += ExportBtn_Click;
            ImportBtn.Click += ImportBtn_Click;
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            saveFileDialog1.FileOk += SaveFileDialog1_FileOk;
            #endregion
        }

        private void CheckIfValidProfile(string filepath)
        {
            if (File.Exists(filepath))
            {
                using (ZipArchive zipArchive = ZipFile.OpenRead(filepath))
                {
                    if (zipArchive.Entries.Count > 0 && zipArchive.GetEntry("info") != null)
                    {
                        string readedInfo = new StreamReader(zipArchive.GetEntry("info").Open()).ReadToEnd().Replace("\r", null); readedInfo = readedInfo.Remove(readedInfo.Length - 1, 1);
                        string[] zipInfo = readedInfo.Split("\n"[0]);
                        if (zipInfo.Length == 3)
                        {
                            string profileName = zipInfo[0];
                            string minecraftVersion = zipInfo[1];
                            string hasOptifineSettings;
                            if (bool.TryParse(zipInfo[2], out bool _)) { hasOptifineSettings = "Yes"; } else { hasOptifineSettings = "No"; }
                            profilesListBox.Items.Add(string.Format("{0,-44}{1,-26}{2}",profileName,minecraftVersion,hasOptifineSettings));
#if DEBUG
                            Debug.WriteLine($"Name: {profileName}\nVersion: {minecraftVersion}\nInclude Optifine settings: {hasOptifineSettings}");
#endif
                            return;
                        }

                    }
                }
#if DEBUG
                Debug.WriteLine($"File:\"{filepath}\" has been deleted because it wasn't a valid file");
#endif
                File.Delete(filepath);
            } else return;

        }

        private void ImportBtn_Click(object sender, EventArgs e) { openFileDialog1.ShowDialog(); }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e) {
            using (ZipArchive archive = ZipFile.OpenRead(openFileDialog1.FileName))
            {
                if (archive.GetEntry("info") != null && new StreamReader(archive.GetEntry("info").Open()).ReadToEnd().GetHashCode() == 1446666046)
                {
                    if(MessageBox.Show($"Profiles: {archive.Entries.Count - 1}\nIf a profile already exists it will be overwritten, continue?",null,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) { return; }

                    foreach(ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name != "info")
                        {
                            entry.ExtractToFile(ApplicationDataDir + entry.Name,true);
                        }
                    }
                    MessageBox.Show($"Successfully imported {archive.Entries.Count - 1} profiles", "Info", MessageBoxButtons.OK,MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("This is not a valid profile export file.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            RefreshSettingsList();
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            if (File.Exists(saveFileDialog1.FileName)) { File.Delete(saveFileDialog1.FileName); }
            ZipFile.CreateFromDirectory(ApplicationDataDir, saveFileDialog1.FileName);
            using (ZipArchive archive = ZipFile.Open(saveFileDialog1.FileName,ZipArchiveMode.Update))
            {
                using(StreamWriter writer = new StreamWriter(archive.CreateEntry("info").Open()))
                {
                    writer.Write(@"#################################################################################################################################
This is a simple file to let the program understand that the package to import was generated by the app itself.                 |
if you wanna import manually the profiles, copy all files(except this one) to the MSavedProfiles folder in your .minecraft path.|
#################################################################################################################################");
                }
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e){ saveFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable("userprofile") + "\\Desktop\\"; saveFileDialog1.ShowDialog(); }

        private void OptifineSettingsCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowOptifineSettings) { optifineSettingsCBox.Checked = false; }
        }

        private void ProfilesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (profilesListBox.SelectedItems.Count > 0) { LoadSettingsBtn.Enabled = true; }
        }

        private void LoadSettingsBtn_Click(object sender, EventArgs e)
        {
            bool confirm = false;
            if(Process.GetProcessesByName("javaw").Length > 0){if (MessageBox.Show("Java is running, make sure that minecraft is not open when applying settings!\nDo you want to continue anyway?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes) { confirm = true; } else { return; }}
            if(profilesListBox.SelectedIndex >= 0)
            {
                string profileFilePath = ApplicationDataDir + profilesListBox.SelectedItem.ToString() + ".smc";
                if (File.Exists(profileFilePath)) //to remove in the future if implementing FileSystemWatcher
                {
                    using (ZipArchive settingsFile = ZipFile.Open(profileFilePath, ZipArchiveMode.Read))
                    {
                        if (confirm || MessageBox.Show("This will overwrite your current settings!\nDo you want to continue?", null, MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) { try { settingsFile.GetEntry("options.txt").ExtractToFile(MinecraftPath + "options.txt", true); } catch (Exception) { MessageBox.Show("An error occurred while loading the settings.\nMake sure that minecraft is closed."); }}
                        MessageBox.Show("Successfully applied settings profile","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(profilesListBox.SelectedIndex != -1)
            {
                string filePath = ApplicationDataDir + profilesListBox.SelectedItem.ToString().Substring(0,profilesListBox.SelectedItem.ToString().LastIndexOf(".") - 2).Replace(" ", null) + ".smc";
                //Need to change the method for getting the filePath because now the program can't delete a profile if it has a space in the name
                File.Delete(filePath);                
                RefreshSettingsList();
            }
        }

        private void DeleteAllProfileBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Choose Wisely",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Directory.Delete(ApplicationDataDir, true);
                Directory.CreateDirectory(ApplicationDataDir);
                RefreshSettingsList();
            }
        }

        private void RefreshSettingsList(object sender = null, EventArgs e = null)
        {
            profilesListBox.Items.Clear();
            profilesListBox.Items.Add(string.Format("{0,-40} {1,-20} {2}","Profile name","MC Version", "Optifine"));
            

            foreach(string filename in Directory.GetFiles(ApplicationDataDir))
            {
                if (filename.EndsWith(".smc")) { CheckIfValidProfile(filename); }
            }

            if (profilesListBox.Items.Count > 0)
            {
                profilesListBox.Enabled = true;
                ExportBtn.Enabled = true;
            }
            else
            {
                profilesListBox.Enabled = false;
                ExportBtn.Enabled = false;
            }

        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("javaw").Length > 0) { MessageBox.Show("Java is running, make sure that Minecraft is closed before using the application!"); }
            if (!Directory.Exists(ApplicationDataDir)) { Directory.CreateDirectory(ApplicationDataDir); }
            minecraftVersionCBox.SelectedIndex = 0;
            if (File.Exists(MinecraftPath + "optionsof.txt") && File.Exists(MinecraftPath + "optionsshaders.txt")) { optifineSettingsCBox.Cursor = Cursors.Default; optifineTooltip.RemoveAll(); allowOptifineSettings = true; }
            RefreshSettingsList();
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {

            if (!File.Exists(MinecraftPath + "options.txt")){MessageBox.Show("There is no minecraft settings file, make sure that you have opened minecraft once."); return;}

            if (string.IsNullOrEmpty(nomeProfiloTxbx.Text))
            {
                MessageBox.Show("Insert a valid name for the profile.");
                return;
            }
            foreach (char item in "+ùàòè*éç°§^?'.\\/#%${}<>$!£ì;,[]:@\"")
            {
                if(nomeProfiloTxbx.Text.Contains(item))
                {
                    MessageBox.Show("Insert a valid name for the profile.");
                    return;
                }
            }



            string filaname = ApplicationDataDir + nomeProfiloTxbx.Text + ".smc";
            if (File.Exists(filaname)) {
                if(MessageBox.Show("A profile with this name already exists. Do you want to overwrite it?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) { return;}
            }



            using (ZipArchive archive = new ZipArchive(File.OpenWrite(ApplicationDataDir + nomeProfiloTxbx.Text + ".smc"),ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(MinecraftPath + "options.txt","options.txt");
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
            RefreshSettingsList();
        }
    }
}
