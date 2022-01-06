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
            this.SaveSettingsBtn = new System.Windows.Forms.Button();
            this.SettingsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadSettingsBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveSettingsBtn
            // 
            this.SaveSettingsBtn.Location = new System.Drawing.Point(12, 282);
            this.SaveSettingsBtn.Name = "SaveSettingsBtn";
            this.SaveSettingsBtn.Size = new System.Drawing.Size(135, 23);
            this.SaveSettingsBtn.TabIndex = 0;
            this.SaveSettingsBtn.Text = "Save current settings";
            this.SaveSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsListBox
            // 
            this.SettingsListBox.ContextMenuStrip = this.RightClickMenu;
            this.SettingsListBox.Enabled = false;
            this.SettingsListBox.FormattingEnabled = true;
            this.SettingsListBox.Location = new System.Drawing.Point(12, 25);
            this.SettingsListBox.Name = "SettingsListBox";
            this.SettingsListBox.Size = new System.Drawing.Size(276, 251);
            this.SettingsListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Saved Settings";
            // 
            // LoadSettingsBtn
            // 
            this.LoadSettingsBtn.Location = new System.Drawing.Point(153, 282);
            this.LoadSettingsBtn.Name = "LoadSettingsBtn";
            this.LoadSettingsBtn.Size = new System.Drawing.Size(135, 23);
            this.LoadSettingsBtn.TabIndex = 3;
            this.LoadSettingsBtn.Text = "Load saved settings";
            this.LoadSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Enabled = false;
            this.ExportBtn.Location = new System.Drawing.Point(12, 311);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(135, 23);
            this.ExportBtn.TabIndex = 4;
            this.ExportBtn.Text = "Export all saved settings";
            this.ExportBtn.UseVisualStyleBackColor = true;
            // 
            // ImportBtn
            // 
            this.ImportBtn.Location = new System.Drawing.Point(153, 311);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(135, 23);
            this.ImportBtn.TabIndex = 5;
            this.ImportBtn.Text = "Import all saved settings";
            this.ImportBtn.UseVisualStyleBackColor = true;
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
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 349);
            this.Controls.Add(this.ImportBtn);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.LoadSettingsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingsListBox);
            this.Controls.Add(this.SaveSettingsBtn);
            this.Name = "GUI";
            this.Text = "Minecraft Settings Saver";
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveSettingsBtn;
        private System.Windows.Forms.ListBox SettingsListBox;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadSettingsBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button ImportBtn;
    }
}

