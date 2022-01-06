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

namespace MinecraftSettingsSaver
{
    public partial class GUI : Form
    {
        static string MinecraftPath = Environment.GetEnvironmentVariable("appdata") + "\\.minecraft\\";
        string ApplicationDataDir = MinecraftPath + "MSavedSettings\\";

        public GUI()
        {
            InitializeComponent();
            #region "Event Handler"
            this.Load += GUI_Load;
            SaveSettingsBtn.Click += SaveSettingsBtn_Click;
            #endregion
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsListBox.Items.Add("Test");
            RefreshSettingsList();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(ApplicationDataDir)) { Directory.CreateDirectory(ApplicationDataDir); }
            if(Process.GetProcessesByName("javaw").Length > 0) { MessageBox.Show("Java is running, make sure that Minecraft is closed before using the application!"); }
            //TODO: getting all savedfile and add to the listbox
        }

        private void SettingsListBox_Changed(object sender, EventArgs e)
        {
            if(SettingsListBox.Items.Count > 0)
            {
                SettingsListBox.Enabled = true;
                ExportBtn.Enabled = true;
            } else
            {
                SettingsListBox.Enabled = false;
                ExportBtn.Enabled = false;
            }
        }

        private void RefreshSettingsList()
        {
            if(SettingsListBox.Items.Count > 0)
            {
                SettingsListBox.Enabled = true;
                ExportBtn.Enabled = true;
            }
            else
            {
                SettingsListBox.Enabled = false;
                ExportBtn.Enabled = false;
            }
        }
    }
}
