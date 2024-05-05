using CowboyBipBoup.Model;

namespace CowboyBipBoup
{
    public partial class MainForm : Form
    {
        private Log.Log? _log = null;

        public MainForm()
        {
            InitializeComponent();

            //_log = new Log.Log(LogRTB);
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

                    managerCB.Rename();
                }

                managerCB.Dispose();
            }
            else
            {
                _log?.Error($"[MainForm]\n" +
                    $"Write a xlsx full path in the text box.");
            }
        }
    }
}
