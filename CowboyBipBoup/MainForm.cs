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
                ManagerCowboy managerCB;

                bool isDataValid = XlsxSerializer.GetData(inputPath, out managerCB);

                if (isDataValid)
                {
                    managerCB.SetFileOutputName(); 
                }
            }
            else
            {
                MessageBox.Show($"Write a xlsx full path in the text box.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
