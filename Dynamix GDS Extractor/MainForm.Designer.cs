namespace Dynamix_GDS_Extractor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NULL0 = new System.Windows.Forms.GroupBox();
            this.HashRootText = new System.Windows.Forms.Label();
            this.NULL26 = new System.Windows.Forms.Label();
            this.OpenFATButton = new System.Windows.Forms.Button();
            this.FileFATText = new System.Windows.Forms.TextBox();
            this.NULL20 = new System.Windows.Forms.Label();
            this.NULL1 = new System.Windows.Forms.GroupBox();
            this.ArchiveList = new System.Windows.Forms.ListBox();
            this.NULL22 = new System.Windows.Forms.Label();
            this.VolumeList = new System.Windows.Forms.ComboBox();
            this.NULL21 = new System.Windows.Forms.Label();
            this.NULL2 = new System.Windows.Forms.GroupBox();
            this.IsFlatText = new System.Windows.Forms.Label();
            this.NULL25 = new System.Windows.Forms.Label();
            this.SizeArchiveText = new System.Windows.Forms.Label();
            this.NULL24 = new System.Windows.Forms.Label();
            this.HashNameText = new System.Windows.Forms.Label();
            this.NULL23 = new System.Windows.Forms.Label();
            this.NULL3 = new System.Windows.Forms.GroupBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.ExportFileButton = new System.Windows.Forms.Button();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DecompressButton = new System.Windows.Forms.Button();
            this.NULL0.SuspendLayout();
            this.NULL1.SuspendLayout();
            this.NULL2.SuspendLayout();
            this.NULL3.SuspendLayout();
            this.SuspendLayout();
            // 
            // NULL0
            // 
            this.NULL0.Controls.Add(this.HashRootText);
            this.NULL0.Controls.Add(this.NULL26);
            this.NULL0.Controls.Add(this.OpenFATButton);
            this.NULL0.Controls.Add(this.FileFATText);
            this.NULL0.Controls.Add(this.NULL20);
            this.NULL0.Location = new System.Drawing.Point(12, 12);
            this.NULL0.Name = "NULL0";
            this.NULL0.Size = new System.Drawing.Size(281, 67);
            this.NULL0.TabIndex = 0;
            this.NULL0.TabStop = false;
            // 
            // HashRootText
            // 
            this.HashRootText.AutoSize = true;
            this.HashRootText.Location = new System.Drawing.Point(87, 45);
            this.HashRootText.Name = "HashRootText";
            this.HashRootText.Size = new System.Drawing.Size(13, 13);
            this.HashRootText.TabIndex = 6;
            this.HashRootText.Text = "--";
            // 
            // NULL26
            // 
            this.NULL26.AutoSize = true;
            this.NULL26.Location = new System.Drawing.Point(6, 45);
            this.NULL26.Name = "NULL26";
            this.NULL26.Size = new System.Drawing.Size(75, 13);
            this.NULL26.TabIndex = 5;
            this.NULL26.Text = "Hash maestro:";
            // 
            // OpenFATButton
            // 
            this.OpenFATButton.Image = global::Dynamix_GDS_Extractor.Properties.Resources.open;
            this.OpenFATButton.Location = new System.Drawing.Point(251, 12);
            this.OpenFATButton.Name = "OpenFATButton";
            this.OpenFATButton.Size = new System.Drawing.Size(22, 22);
            this.OpenFATButton.TabIndex = 0;
            this.OpenFATButton.TabStop = false;
            this.OpenFATButton.UseVisualStyleBackColor = true;
            this.OpenFATButton.Click += new System.EventHandler(this.OpenFATButton_Click);
            // 
            // FileFATText
            // 
            this.FileFATText.Location = new System.Drawing.Point(42, 13);
            this.FileFATText.Name = "FileFATText";
            this.FileFATText.ReadOnly = true;
            this.FileFATText.Size = new System.Drawing.Size(203, 20);
            this.FileFATText.TabIndex = 0;
            this.FileFATText.TabStop = false;
            // 
            // NULL20
            // 
            this.NULL20.AutoSize = true;
            this.NULL20.Location = new System.Drawing.Point(6, 16);
            this.NULL20.Name = "NULL20";
            this.NULL20.Size = new System.Drawing.Size(30, 13);
            this.NULL20.TabIndex = 1;
            this.NULL20.Text = "FAT:";
            // 
            // NULL1
            // 
            this.NULL1.Controls.Add(this.ArchiveList);
            this.NULL1.Controls.Add(this.NULL22);
            this.NULL1.Controls.Add(this.VolumeList);
            this.NULL1.Controls.Add(this.NULL21);
            this.NULL1.Location = new System.Drawing.Point(12, 85);
            this.NULL1.Name = "NULL1";
            this.NULL1.Size = new System.Drawing.Size(128, 223);
            this.NULL1.TabIndex = 1;
            this.NULL1.TabStop = false;
            // 
            // ArchiveList
            // 
            this.ArchiveList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchiveList.FormattingEnabled = true;
            this.ArchiveList.ItemHeight = 14;
            this.ArchiveList.Location = new System.Drawing.Point(6, 85);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ScrollAlwaysVisible = true;
            this.ArchiveList.Size = new System.Drawing.Size(116, 130);
            this.ArchiveList.TabIndex = 1;
            this.ArchiveList.SelectedIndexChanged += new System.EventHandler(this.ArchiveList_SelectedIndexChanged);
            // 
            // NULL22
            // 
            this.NULL22.AutoSize = true;
            this.NULL22.Location = new System.Drawing.Point(6, 67);
            this.NULL22.Name = "NULL22";
            this.NULL22.Size = new System.Drawing.Size(51, 13);
            this.NULL22.TabIndex = 3;
            this.NULL22.Text = "Archivos:";
            // 
            // VolumeList
            // 
            this.VolumeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VolumeList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumeList.FormattingEnabled = true;
            this.VolumeList.Location = new System.Drawing.Point(6, 32);
            this.VolumeList.Name = "VolumeList";
            this.VolumeList.Size = new System.Drawing.Size(116, 22);
            this.VolumeList.TabIndex = 0;
            this.VolumeList.TabStop = false;
            this.VolumeList.SelectedIndexChanged += new System.EventHandler(this.VolumeList_SelectedIndexChanged);
            // 
            // NULL21
            // 
            this.NULL21.AutoSize = true;
            this.NULL21.Location = new System.Drawing.Point(6, 16);
            this.NULL21.Name = "NULL21";
            this.NULL21.Size = new System.Drawing.Size(62, 13);
            this.NULL21.TabIndex = 2;
            this.NULL21.Text = "Volúmenes:";
            // 
            // NULL2
            // 
            this.NULL2.Controls.Add(this.IsFlatText);
            this.NULL2.Controls.Add(this.NULL25);
            this.NULL2.Controls.Add(this.SizeArchiveText);
            this.NULL2.Controls.Add(this.NULL24);
            this.NULL2.Controls.Add(this.HashNameText);
            this.NULL2.Controls.Add(this.NULL23);
            this.NULL2.Location = new System.Drawing.Point(146, 85);
            this.NULL2.Name = "NULL2";
            this.NULL2.Size = new System.Drawing.Size(147, 78);
            this.NULL2.TabIndex = 2;
            this.NULL2.TabStop = false;
            // 
            // IsFlatText
            // 
            this.IsFlatText.AutoSize = true;
            this.IsFlatText.Location = new System.Drawing.Point(60, 55);
            this.IsFlatText.Name = "IsFlatText";
            this.IsFlatText.Size = new System.Drawing.Size(13, 13);
            this.IsFlatText.TabIndex = 8;
            this.IsFlatText.Text = "--";
            // 
            // NULL25
            // 
            this.NULL25.AutoSize = true;
            this.NULL25.Location = new System.Drawing.Point(6, 55);
            this.NULL25.Name = "NULL25";
            this.NULL25.Size = new System.Drawing.Size(48, 13);
            this.NULL25.TabIndex = 7;
            this.NULL25.Text = "Formato:";
            // 
            // SizeArchiveText
            // 
            this.SizeArchiveText.AutoSize = true;
            this.SizeArchiveText.Location = new System.Drawing.Point(61, 35);
            this.SizeArchiveText.Name = "SizeArchiveText";
            this.SizeArchiveText.Size = new System.Drawing.Size(13, 13);
            this.SizeArchiveText.TabIndex = 6;
            this.SizeArchiveText.Text = "--";
            // 
            // NULL24
            // 
            this.NULL24.AutoSize = true;
            this.NULL24.Location = new System.Drawing.Point(6, 35);
            this.NULL24.Name = "NULL24";
            this.NULL24.Size = new System.Drawing.Size(49, 13);
            this.NULL24.TabIndex = 5;
            this.NULL24.Text = "Tamaño:";
            // 
            // HashNameText
            // 
            this.HashNameText.AutoSize = true;
            this.HashNameText.Location = new System.Drawing.Point(47, 16);
            this.HashNameText.Name = "HashNameText";
            this.HashNameText.Size = new System.Drawing.Size(13, 13);
            this.HashNameText.TabIndex = 4;
            this.HashNameText.Text = "--";
            this.MainToolTip.SetToolTip(this.HashNameText, "Hash generado: ");
            // 
            // NULL23
            // 
            this.NULL23.AutoSize = true;
            this.NULL23.Location = new System.Drawing.Point(6, 16);
            this.NULL23.Name = "NULL23";
            this.NULL23.Size = new System.Drawing.Size(35, 13);
            this.NULL23.TabIndex = 3;
            this.NULL23.Text = "Hash:";
            // 
            // NULL3
            // 
            this.NULL3.Controls.Add(this.DecompressButton);
            this.NULL3.Controls.Add(this.ExitButton);
            this.NULL3.Controls.Add(this.AboutButton);
            this.NULL3.Controls.Add(this.ExportFileButton);
            this.NULL3.Location = new System.Drawing.Point(146, 169);
            this.NULL3.Name = "NULL3";
            this.NULL3.Size = new System.Drawing.Size(147, 139);
            this.NULL3.TabIndex = 3;
            this.NULL3.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(6, 109);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(133, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "&Salir";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(6, 79);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(133, 24);
            this.AboutButton.TabIndex = 0;
            this.AboutButton.TabStop = false;
            this.AboutButton.Text = "Acerca de DGDS...";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ExportFileButton
            // 
            this.ExportFileButton.Location = new System.Drawing.Point(6, 19);
            this.ExportFileButton.Name = "ExportFileButton";
            this.ExportFileButton.Size = new System.Drawing.Size(133, 24);
            this.ExportFileButton.TabIndex = 2;
            this.ExportFileButton.Text = "&Exportar a...";
            this.ExportFileButton.UseVisualStyleBackColor = true;
            this.ExportFileButton.Click += new System.EventHandler(this.ExportFileButton_Click);
            // 
            // DecompressButton
            // 
            this.DecompressButton.Location = new System.Drawing.Point(6, 49);
            this.DecompressButton.Name = "DecompressButton";
            this.DecompressButton.Size = new System.Drawing.Size(133, 24);
            this.DecompressButton.TabIndex = 4;
            this.DecompressButton.TabStop = false;
            this.DecompressButton.Text = "Descomprimir y e&xportar";
            this.DecompressButton.UseVisualStyleBackColor = true;
            this.DecompressButton.Click += new System.EventHandler(this.DecompressButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 321);
            this.Controls.Add(this.NULL3);
            this.Controls.Add(this.NULL2);
            this.Controls.Add(this.NULL1);
            this.Controls.Add(this.NULL0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamix Game Development System Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.NULL0.ResumeLayout(false);
            this.NULL0.PerformLayout();
            this.NULL1.ResumeLayout(false);
            this.NULL1.PerformLayout();
            this.NULL2.ResumeLayout(false);
            this.NULL2.PerformLayout();
            this.NULL3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox NULL0;
        private System.Windows.Forms.Label NULL20;
        private System.Windows.Forms.Button OpenFATButton;
        private System.Windows.Forms.TextBox FileFATText;
        private System.Windows.Forms.GroupBox NULL1;
        private System.Windows.Forms.ListBox ArchiveList;
        private System.Windows.Forms.Label NULL22;
        private System.Windows.Forms.ComboBox VolumeList;
        private System.Windows.Forms.Label NULL21;
        private System.Windows.Forms.GroupBox NULL2;
        private System.Windows.Forms.GroupBox NULL3;
        private System.Windows.Forms.Label HashNameText;
        private System.Windows.Forms.Label NULL23;
        private System.Windows.Forms.Label IsFlatText;
        private System.Windows.Forms.Label NULL25;
        private System.Windows.Forms.Label SizeArchiveText;
        private System.Windows.Forms.Label NULL24;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button ExportFileButton;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Label HashRootText;
        private System.Windows.Forms.Label NULL26;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.Button DecompressButton;
    }
}

