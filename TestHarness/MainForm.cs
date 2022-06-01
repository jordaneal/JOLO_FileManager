using JOLO_FileManager;
using System.Text;

namespace TestHarness
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
                ofd.FilterIndex = 0;
                ofd.Multiselect = false;
                DialogResult = ofd.ShowDialog();

                if (DialogResult == DialogResult.OK)
                {
                    FileManager fm = new(ofd.FileName);
                    StringBuilder sb = new();

                    sb.Append(
                        $"File Exists: {fm.FileExists()}\n" +
                        $"Directory Name: {fm.DirectoryName()}\n" +
                        $"Largest File in Current Directory: {fm.LargestFileInCurrentDirectory()}\n" +
                        $"Vowel Weight: {fm.VowelWeight()}\n" +
                        $"File Name: {fm.FileName()}\n" +
                        $"File Extension: {fm.FileExtension()}\n" +
                        $"Decoded Byte Array: {Encoding.Default.GetString(fm.GetByteArray()!)}\n" +
                        $"ToString() \n{fm}");

                    MessageBox.Show(sb.ToString());
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}