namespace ComputerGraphics.Windows
{
    public static class WindowController
    {
        private static readonly MainWindow MainWindow;

        static WindowController()
        {
            MainWindow = new MainWindow();
        }

        public static void ShowMainWindow()
        {
            if (!MainWindow.IsVisible) MainWindow.Show();
        }
    }
}