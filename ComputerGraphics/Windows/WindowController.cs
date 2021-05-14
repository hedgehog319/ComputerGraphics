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
        private static InfoWindow _info;
        private static Simulator _simulator;

        public static ChartModels ChartModels;

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

            _navBar = new NavBar {Owner = MainWindow};
            _navBar.Closed += (_, _) => _navBar = null;
            _navBar.Show();
        }

        public static void AddOscillogram(int modelId)
        {
            if (_oscillogramViewer == null)
            {
                _oscillogramViewer = new OscillogramViewer {Owner = MainWindow};
                _oscillogramViewer.Closed += (s, e) => _oscillogramViewer = null;
                _oscillogramViewer.Show();
            }

            _oscillogramViewer.AddOscillogram(modelId);
        }

        public static bool ReadFile()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != true) return false;

            ChartModels = ChannelReader.ReadTxt(dialog.FileName);

            return true;
        }

        public static void ShowInfoWindow()
        {
            if (_info != null) return;

            _info = new InfoWindow {Owner = MainWindow};
            _info.Closed += (_, _) => _info = null;
            _info.Show();
        }

        public static void ShowSimulator()
        {
            if (_simulator != null) return;

            _simulator = new Simulator {Owner = MainWindow};
            _simulator.Closed += (_, _) => _simulator = null;
            _simulator.Show();
        }

        public static void CreateNewSignal()
        {
            var dialog = new NewSignalCreator {Owner = MainWindow};
            if (dialog.ShowDialog() == true)
            {
                ChartModels = new ChartModels(dialog.SamplesNumber, dialog.SamplingRate);
                // TODO close navbar and etc.
            }
        }
    }
}