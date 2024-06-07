namespace CowboyBipBoup.View
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Shown(object sender, EventArgs e)
        {
            StartProcess();
        }

        private async void StartProcess()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.modem);
            player.PlayLooping();

            await Task.Run(() =>
            {
                while (OldProgressBar.Value < OldProgressBar.Maximum)
                {
                    OldProgressBar.Invoke(delegate { OldProgressBar.PerformStep(); });

                    Thread.Sleep(50);
                }
            });

            player.Stop();
            this.Close();
        }
    }
}
