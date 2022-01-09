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
        string ApplicationDataDir = MinecraftPath + "MSavedSettings\\";
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
            #endregion
        }

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
            if(profilesListBox.SelectedIndex >= 0)
            {
                string profileFilePath = ApplicationDataDir + profilesListBox.SelectedItem.ToString() + ".smc";
                if (File.Exists(profileFilePath))
                {
                    using (ZipArchive settingsFile = ZipFile.Open(profileFilePath, ZipArchiveMode.Read))
                    {
                        if (settingsFile.GetEntry("info") == null){MessageBox.Show("The selected file is not a valid minecraft settings profile.");}

                        if (MessageBox.Show("This will overwrite your current settings!\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                settingsFile.GetEntry("options.txt").ExtractToFile(MinecraftPath + "options.txt",true);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("An error occurred while loading the settings.\nMake sure that minecraft is closed.");
#if DEBUG
                                throw;
#endif
                            }
                        }
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(profilesListBox.SelectedIndex != -1)
            {
                string filepath = ApplicationDataDir + profilesListBox.SelectedItem.ToString() + ".smc";
                if (File.Exists(filepath))
                {
                    try
                    {
                        File.Delete(filepath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to remove the saved profile", "Error");
                        return;
                    }
                }
                RefreshSettingsList();
            }
        }

        private void DeleteAllProfileBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Directory.Delete(ApplicationDataDir, true);
                Directory.CreateDirectory(ApplicationDataDir);
                RefreshSettingsList();
            }
        }

        private void RefreshSettingsList(object sender = null, EventArgs e = null)
        {
            profilesListBox.Items.Clear();

            foreach(string filename in Directory.GetFiles(ApplicationDataDir))
            {
                profilesListBox.Items.Add(filename.Replace(ApplicationDataDir,null).Replace(".smc",null));
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
