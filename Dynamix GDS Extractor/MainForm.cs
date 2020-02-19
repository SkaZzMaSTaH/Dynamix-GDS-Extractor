using System;
using System.IO;
using System.Windows.Forms;

namespace Dynamix_GDS_Extractor
{
    public partial class MainForm : Form
    {
        Manager.Brain MotherBrain = null;

        public MainForm()
        {
            InitializeComponent();

            DisableGUI();
        }

        #region Scripted Events
        private void ShowErrorMessage(string errMessage)
        {
            MessageBox.Show(
                "Se ha producido el siguiente error:" + Environment.NewLine + Environment.NewLine + errMessage,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void DisableGUI()
        {
            FileFATText.Enabled = false;

            VolumeList.Enabled = false;
            ArchiveList.Enabled = false;

            ExportFileButton.Enabled = false;

            DecompressButton.Enabled = false;

            MainToolTip.ToolTipIcon = ToolTipIcon.Info;
            MainToolTip.ToolTipTitle = "Información";
            MainToolTip.SetToolTip(HashNameText, "Aquí se mostrará el hash generado...");
        }
        private void EnableGUI()
        {
            FileFATText.Enabled = true;

            VolumeList.Enabled = true;
            ArchiveList.Enabled = true;

            ExportFileButton.Enabled = true;

            DecompressButton.Enabled = true;
        }

        private void FillVolumeList()
        {
            VolumeList.Items.Clear();

            foreach (FileFormat.FAT.VolumeGameArchive VGA in MotherBrain.VGArchives)
            {
                VolumeList.Items.Add(VGA.FileName);
            }

            VolumeList.SelectedIndex = 0;
        }
        private void FillArchiveList()
        {
            ArchiveList.Items.Clear();

            foreach (FileFormat.Resource.Archive Archive in MotherBrain.VolumeSelected.Archives)
            {
                ArchiveList.Items.Add(Archive.FileName);
            }

            ArchiveList.SelectedIndex = 0;
        }
        
        private void ShowVGIndexInfo()
        {
            FileFATText.Text = MotherBrain.VGIndex.File;

            HashRootText.Text = Convert.ToString(MotherBrain.VGIndex.HashRoot);
        }
        private void ShowVGArchiveInfo()
        {
            const string HASH_OK = "... ok", HASH_ERROR = "... error";
            const ToolTipIcon TOOLTIP_HASH_OK = ToolTipIcon.Info, TOOLTIP_HASH_ERROR = ToolTipIcon.Error;
            const string FORMAT_FLAT = "Plano", FORMAT_CHUNK = "Chunk";

            int hashNameBuild = Lib.Toolkit.CreateHashName(
                MotherBrain.ArchiveSelected.FileName.ToCharArray(),
                MotherBrain.VGIndex.HashRoot);
            int hashName = MotherBrain.VGIndex.VolumeIndexes[VolumeList.SelectedIndex].HashNames[ArchiveList.SelectedIndex];

            HashNameText.Text = Convert.ToString(hashName);
            HashNameText.Text += (hashNameBuild == hashName) ? HASH_OK : HASH_ERROR;

            MainToolTip.ToolTipIcon = (hashNameBuild == hashName) ? TOOLTIP_HASH_OK : TOOLTIP_HASH_ERROR;
            MainToolTip.SetToolTip(HashNameText, "Hash generado: " + Convert.ToString(hashNameBuild));

            SizeArchiveText.Text = Convert.ToString(MotherBrain.ArchiveSelected.Size) + " bytes";

            IsFlatText.Text = (MotherBrain.ArchiveSelected.IsFlat == true) ? FORMAT_FLAT : FORMAT_CHUNK;
        }

        private void ImportVolumes()
        {
            const string FILE_EXT = @"Archivo de volumen|*.vga;*.rmf;*.map|Todos los archivos|*.*";

            OpenFileDialog.Filter = FILE_EXT;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            //try
            //{
                MotherBrain = new Manager.Brain(Lib.Explode.LoadFAT(OpenFileDialog.FileName));

                for (int i = 0; i < MotherBrain.VGIndex.Count; i++)
                {
                    MotherBrain.AddArchive(Lib.Explode.LoadVolume(MotherBrain.VGIndex, i));
                }

                ShowVGIndexInfo();
                EnableGUI();
                FillVolumeList();
            //}
            //catch (Exception err)
            //{
                //ShowErrorMessage(err.Message);
                //DisableGUI();
            //}
        }
        private void ExportArchive()
        {
            SaveFileDialog.Filter =
                "Archivo " +
                MotherBrain.ArchiveSelected.FileExtension +
                "|*" + MotherBrain.ArchiveSelected.FileExtension +
                "|Todos los archivos|*.*";
            SaveFileDialog.FileName = Path.GetFileNameWithoutExtension(MotherBrain.ArchiveSelected.FileName);
            SaveFileDialog.InitialDirectory = MotherBrain.VGIndex.FilePath;

            if (SaveFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            try
            {
                Lib.Implode.SaveResource(MotherBrain.ArchiveSelected, SaveFileDialog.FileName);
            }
            catch (Exception err)
            {
                ShowErrorMessage(err.Message);
            }
        }
        #endregion
        #region System events
        private void OpenFATButton_Click(object sender, EventArgs e)
        {
            ImportVolumes();
        }
        private void ExportFileButton_Click(object sender, EventArgs e)
        {
            ExportArchive();
        }
        private void DecompressButton_Click(object sender, EventArgs e)
        {
            try
            {
                MotherBrain.ArchiveSelected.DecodeData();
            }
            catch (Exception err)
            {
                ShowErrorMessage("Error descodificando el archivo." + Environment.NewLine + err.Message);
            }

            ShowVGArchiveInfo();
            ExportArchive();
        }
        private void AboutButton_Click(object sender, EventArgs e)
        {
            Manager.AssemblyInfo SoftInfo = new Manager.AssemblyInfo();

            MessageBox.Show(
                SoftInfo.Product + " " +
                "v" + SoftInfo.FileVersion + Environment.NewLine +
                SoftInfo.Description + Environment.NewLine + Environment.NewLine +
                SoftInfo.Company + Environment.NewLine +
                SoftInfo.Copyright + Environment.NewLine,
                SoftInfo.Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);            
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VolumeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int volumeIndex = VolumeList.SelectedIndex;
            MotherBrain.VolumeSelected = (volumeIndex < 0) ? null : MotherBrain.VGArchives[volumeIndex];

            if (MotherBrain.VolumeSelected == null) { return; }

            FillArchiveList();
        }
        private void ArchiveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int archiveIndex = ArchiveList.SelectedIndex;

            MotherBrain.ArchiveSelected = (archiveIndex < 0) ? null : MotherBrain.VolumeSelected.Archives[archiveIndex];

            if (MotherBrain.ArchiveSelected == null) { return; }

            if (Lib.Toolkit.IsArchiveCompressed(MotherBrain.ArchiveSelected))
            {
                DecompressButton.Enabled = true;
            }
            else
            {
                DecompressButton.Enabled = false;
            }

            ShowVGArchiveInfo();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { AboutButton.PerformClick(); }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Quieres salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
