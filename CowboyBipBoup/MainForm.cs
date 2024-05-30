using CowboyBipBoup.Controler;

namespace CowboyBipBoup
{
    public partial class MainForm : Form
    {
        private Log.Log? _log = null;
        private CowboyControler _controler;

        public MainForm()
        {
            InitializeComponent();

            _log = new Log.Log(LogRTB);
            _controler = new CowboyControler(_log);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            string inputPath = InputTextBox.Text;

            if (!string.IsNullOrEmpty(inputPath))
            {
                _controler.Start(inputPath, RenameOnlyCheckBox.Checked, StartBtn);
            }
            else
            {
                _log?.Error($"[MainForm]\n" +
                    $"Write a xlsx full path in the text box.");
            }
        }
    }
}
