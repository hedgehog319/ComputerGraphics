using System;
using System.Windows;
using ComputerGraphics.ScrollView;
using ComputerGraphics.Utils;
using ComputerGraphics.Windows;

namespace ComputerGraphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            var msg = "Просграмма DSP позволяет визуализировать сигналы с различных устройств.\n" +
                      "Разработчики: Торжков А., Просин А., Антипов Д.";
            MessageBox.Show(msg, "О программе");
        }

        private void TestDown(object sender, RoutedEventArgs e)
        {
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (fileDialog.ShowDialog() != true) return;

            _multiChannel = ChannelReader.ReadFile(fileDialog.FileName);
            Console.WriteLine(_multiChannel[0][2094]);
        }

        private MultiChannel<double> _multiChannel;

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            // new testWindow(_multiChannel[0]).Show();
            var data = new ScrollableViewModel(_multiChannel[0]);
            var wind = new testWindow();
            wind.Plot.DataContext = data;
            wind.Show();
        }
    }
}