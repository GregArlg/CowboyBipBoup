using CowboyBipBoup.Model;

namespace CowboyBipBoup
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            string inputPath = InputTextBox.Text;

            if (!string.IsNullOrEmpty(inputPath))
            {
                var managerCB = XlsxSerializer.GetData(inputPath);
            }
            else
            {
                MessageBox.Show($"Write a xlsx full path in the text box.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
