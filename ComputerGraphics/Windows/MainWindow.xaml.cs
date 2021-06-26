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

            WindowController.CloseNavBar();
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

        private void Navigation_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.ShowNavBar();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Разработчики программы:\n" +
                "Торжков Александр\n" +
                "Просин Андрей\n" +
                "Антипов Данил\n" +
                "Немиро Максим\n\n" +
                "Программа DSP предназначена для визуализации многоканальных сигналов"
                , "О программе");
        }
    }
}