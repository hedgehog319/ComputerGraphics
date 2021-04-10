using ComputerGraphics.ChartsViews;
using ComputerGraphics.Windows.Main;
using ComputerGraphics.Windows.Oscillogram;

namespace ComputerGraphics.Windows
{
    public static class WindowsController
    {
        private static MainWindow _main;

        // private static NavBar _navBar;

        private static OscillogramViewer _oscillogramViewer;
        public static OscillogramModel OscillogramModel { get; } = new();

        public static void SetMainWindow(MainWindow window) => _main = window;

        public static bool IsOscillogramViewerVisiable => _oscillogramViewer != null;

        public static void NewOscillogramViewer()
        {
            _oscillogramViewer = new OscillogramViewer(OscillogramModel) {Owner = _main};
            _oscillogramViewer.Closed += (_, _) => _oscillogramViewer = null;
            _oscillogramViewer.Show();
        }
    }
}