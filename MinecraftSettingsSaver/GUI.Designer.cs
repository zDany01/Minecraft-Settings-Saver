namespace MinecraftSettingsSaver
{
    partial class GUI
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SaveProfileBtn = new System.Windows.Forms.Button();
            this.profilesListBox = new System.Windows.Forms.ListBox();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadSettingsBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.deleteAllProfileBtn = new System.Windows.Forms.Button();
            this.profileNameTxbx = new System.Windows.Forms.TextBox();
            this.minecraftVersionCBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optifineSettingsCBox = new System.Windows.Forms.CheckBox();
            this.optifineTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.saveProfilesDialog = new System.Windows.Forms.SaveFileDialog();
            this.importProfilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveProfileBtn
            // 
            this.SaveProfileBtn.Location = new System.Drawing.Point(12, 318);
            this.SaveProfileBtn.Name = "SaveProfileBtn";
            this.SaveProfileBtn.Size = new System.Drawing.Size(143, 23);
            this.SaveProfileBtn.TabIndex = 0;
            this.SaveProfileBtn.Text = "Save current settings";
            this.SaveProfileBtn.UseVisualStyleBackColor = true;
            // 
            // profilesListBox
            // 
            this.profilesListBox.ContextMenuStrip = this.RightClickMenu;
            this.profilesListBox.Enabled = false;
            this.profilesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilesListBox.FormattingEnabled = true;
            this.profilesListBox.Location = new System.Drawing.Point(12, 25);
            this.profilesListBox.Name = "profilesListBox";
            this.profilesListBox.ScrollAlwaysVisible = true;
            this.profilesListBox.Size = new System.Drawing.Size(292, 251);
            this.profilesListBox.TabIndex = 1;
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.Size = new System.Drawing.Size(111, 48);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Saved profiles";
            // 
            // LoadSettingsBtn
            // 
            this.LoadSettingsBtn.Enabled = false;
            this.LoadSettingsBtn.Location = new System.Drawing.Point(12, 347);
            this.LoadSettingsBtn.Name = "LoadSettingsBtn";
            this.LoadSettingsBtn.Size = new System.Drawing.Size(143, 23);
            this.LoadSettingsBtn.TabIndex = 3;
            this.LoadSettingsBtn.Text = "Load saved profile";
            this.LoadSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExportBtn.Enabled = false;
            this.ExportBtn.Location = new System.Drawing.Point(12, 376);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(143, 23);
            this.ExportBtn.TabIndex = 4;
            this.ExportBtn.Text = "Export all saved profiles";
            this.ExportBtn.UseVisualStyleBackColor = true;
            // 
            // ImportBtn
            // 
            this.ImportBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImportBtn.Location = new System.Drawing.Point(161, 376);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(143, 23);
            this.ImportBtn.TabIndex = 5;
            this.ImportBtn.Text = "Import profiles from file";
            this.ImportBtn.UseVisualStyleBackColor = true;
            // 
            // deleteAllProfileBtn
            // 
            this.deleteAllProfileBtn.Location = new System.Drawing.Point(161, 347);
            this.deleteAllProfileBtn.Name = "deleteAllProfileBtn";
            this.deleteAllProfileBtn.Size = new System.Drawing.Size(143, 23);
            this.deleteAllProfileBtn.TabIndex = 6;
            this.deleteAllProfileBtn.Text = "Delete all saved profiles";
            this.deleteAllProfileBtn.UseVisualStyleBackColor = true;
            // 
            // profileNameTxbx
            // 
            this.profileNameTxbx.Location = new System.Drawing.Point(12, 295);
            this.profileNameTxbx.MaxLength = 20;
            this.profileNameTxbx.Name = "profileNameTxbx";
            this.profileNameTxbx.Size = new System.Drawing.Size(199, 20);
            this.profileNameTxbx.TabIndex = 7;
            // 
            // minecraftVersionCBox
            // 
            this.minecraftVersionCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minecraftVersionCBox.Items.AddRange(new object[] {
            "1.19",
            "1.18",
            "1.17",
            "1.16",
            "1.15",
            "1.14",
            "1.13",
            "1.12",
            "1.11",
            "1.10",
            "1.9",
            "1.8",
            "1.7"});
            this.minecraftVersionCBox.Location = new System.Drawing.Point(217, 295);
            this.minecraftVersionCBox.Name = "minecraftVersionCBox";
            this.minecraftVersionCBox.Size = new System.Drawing.Size(87, 21);
            this.minecraftVersionCBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Profile name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Minecraft version";
            // 
            // optifineSettingsCBox
            // 
            this.optifineSettingsCBox.AutoSize = true;
            this.optifineSettingsCBox.Cursor = System.Windows.Forms.Cursors.No;
            this.optifineSettingsCBox.Location = new System.Drawing.Point(163, 322);
            this.optifineSettingsCBox.Name = "optifineSettingsCBox";
            this.optifineSettingsCBox.Size = new System.Drawing.Size(139, 17);
            this.optifineSettingsCBox.TabIndex = 11;
            this.optifineSettingsCBox.Text = "Include Optifine settings";
            this.optifineTooltip.SetToolTip(this.optifineSettingsCBox, "The program can\'t find optifine configuration file.");
            this.optifineSettingsCBox.UseVisualStyleBackColor = true;
            // 
            // saveProfilesDialog
            // 
            this.saveProfilesDialog.DefaultExt = "zip";
            this.saveProfilesDialog.Filter = "Zip file|*.zip";
            this.saveProfilesDialog.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)";
            this.saveProfilesDialog.Title = "Save As...";
            // 
            // importProfilesDialog
            // 
            this.importProfilesDialog.DefaultExt = "zip";
            this.importProfilesDialog.Filter = "Zip file|*.zip";
            this.importProfilesDialog.Title = "Open...";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 405);
            this.Controls.Add(this.optifineSettingsCBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minecraftVersionCBox);
            this.Controls.Add(this.profileNameTxbx);
            this.Controls.Add(this.deleteAllProfileBtn);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.LoadSettingsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profilesListBox);
            this.Controls.Add(this.SaveProfileBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Settings Saver";
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveProfileBtn;
        private System.Windows.Forms.ListBox profilesListBox;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadSettingsBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.Button deleteAllProfileBtn;
        private System.Windows.Forms.TextBox profileNameTxbx;
        private System.Windows.Forms.ComboBox minecraftVersionCBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox optifineSettingsCBox;
        private System.Windows.Forms.ToolTip optifineTooltip;
        private System.Windows.Forms.SaveFileDialog saveProfilesDialog;
        private System.Windows.Forms.OpenFileDialog importProfilesDialog;
    }
}

