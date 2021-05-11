#region

using System.Windows;

#endregion

namespace ComputerGraphics.Windows
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            if (!WindowController.ReadFile()) return;

            WindowController.ShowNavBar();
        }

        private void Information_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.ShowInfoWindow();
        }
    }
}