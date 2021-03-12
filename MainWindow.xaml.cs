using System;
using ComputerGraphics.Components;
using System.Windows;
using System.IO;
using ComputerGraphics.Utils;
using Microsoft.Win32;

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
            const string msg = "Просграмма DSP позволяет визуализировать сигналы с различных устройств.\n" +
                               "Разработчики: Торжков А., Просин А., Антипов Д.";
            MessageBox.Show(msg, "О программе");
        }

        private void Button_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!(sender is Button btn)) return;

            MessageBox.Show(btn.Height + " " + btn.Width);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (fileDialog.ShowDialog() != true) return;

            var multiChannel = ChannelReader.ReadFile(fileDialog.FileName);
        }
    }
}