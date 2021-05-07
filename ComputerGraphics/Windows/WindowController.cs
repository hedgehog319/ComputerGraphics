#region

using ComputerGraphics.Charts;
using ComputerGraphics.Signal;
using Microsoft.Win32;

#endregion

namespace ComputerGraphics.Windows
{
    public static class WindowController
    {
        private static readonly MainWindow MainWindow;
        private static NavBar _navBar;
        private static OscillogramViewer _oscillogramViewer;

        private static Models _models;

        static WindowController()
        {
            MainWindow = new MainWindow();
        }

        public static void ShowMainWindow()
        {
            if (!MainWindow.IsVisible) MainWindow.Show();
        }

        public static void ShowNavBar()
        {
            if (_navBar != null) return;

            _navBar = new NavBar(_models) {Owner = MainWindow};
            _navBar.Closed += (s, e) => _navBar = null;
            _navBar.Show();
        }

        public static void AddOscillogram(BaseModel model)
        {
            if (_oscillogramViewer == null)
            {
                _oscillogramViewer = new OscillogramViewer {Owner = MainWindow};
                _oscillogramViewer.Closed += (s, e) => _oscillogramViewer = null;
                _oscillogramViewer.Show();
            }

            // TODO Not save!
            _oscillogramViewer.AddOscillogram(model as OscillogramModel);
        }

        public static bool ReadFile()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != true) return false;

            _models = ChannelReader.ReadTxt(dialog.FileName);

            return true;
        }
    }
}