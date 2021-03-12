using System;
using System.Windows;
using System.IO;
using ComputerGraphics.Utils;
using Microsoft.Win32;
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
            // #if DEBUG
                // new testWindow().Show();
                // this.Hide();
            // #endif
        }

        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            var msg = "Просграмма DSP позволяет визуализировать сигналы с различных устройств.\n" +
                      "Разработчики: Торжков А., Просин А., Антипов Д.";
            MessageBox.Show(msg, "О программе");
        }

        private void Button_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
        }

        private MultiChannel<double> _multiChannel;
        
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            new testWindow(_multiChannel[0]).Show();
        }
    }
}