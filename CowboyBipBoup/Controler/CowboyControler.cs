using CowboyBipBoup.Model;

namespace CowboyBipBoup.Controler
{
    public class CowboyControler
    {
        private Log.Log? _log = null;

        public CowboyControler(Log.Log? log = null)
        {
            _log = log;
        }

        public void Start(string inputPath, bool isRenameOnly, Control toDisable)
        {
            Task.Run(() =>
            {
                toDisable.Invoke(delegate { toDisable.Enabled = false; });

                _ProcessLauncher(inputPath, isRenameOnly);

                toDisable.Invoke(delegate { toDisable.Enabled = true; });
            });
        }

        private void _ProcessLauncher(string inputPath, bool isRenameOnly)
        {
            ManagerCowboy managerCB;

            bool isDataValid = XlsxSerializer.GetData(inputPath, out managerCB, _log);

            if (isDataValid)
            {
                managerCB.SetFileOutputName();

                managerCB.RenameAndMove(isRenameOnly);
            }

            managerCB.Dispose();
        }
    }
}
