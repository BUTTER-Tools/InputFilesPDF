using System.Text;
using System.Windows.Forms;

namespace InputFilesPDF
{
    internal partial class SettingsForm_InputFilesPDF : Form
    {


        #region Get and Set Options

        public string TextFileDirectory { get; set; }
        public bool ScanSubfolders { get; set; }

       #endregion



        public SettingsForm_InputFilesPDF(string TextFileDirectory, bool ScanSubfolders)
        {
            InitializeComponent();

            IncludeSubfoldersCheckbox.Checked = ScanSubfolders;
            SelectedFolderTextbox.Text = TextFileDirectory;

        }






        private void SetFolderButton_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = false;
                dialog.Description = "Please choose the location of your PDF files to analyze";
                if (!string.IsNullOrWhiteSpace(SelectedFolderTextbox.Text)) dialog.SelectedPath = SelectedFolderTextbox.Text;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFolderTextbox.Text = dialog.SelectedPath.ToString();
                }
            }
        }


        private void OKButton_Click(object sender, System.EventArgs e)
        {
            this.ScanSubfolders = IncludeSubfoldersCheckbox.Checked;
            this.TextFileDirectory = SelectedFolderTextbox.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
