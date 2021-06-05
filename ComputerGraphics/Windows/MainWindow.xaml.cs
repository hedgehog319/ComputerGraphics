#region

using System.Windows;

#endregion

namespace ComputerGraphics.Windows
{
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

        private void Simulation_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.ShowSimulator();
        }

        private void NewSignal_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.CreateNewSignal();
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.SaveSignal();
        }

        private void Statistic_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.ShowStatistics();
        }

        private void Navigation_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.ShowNavBar();
        }
    }
}