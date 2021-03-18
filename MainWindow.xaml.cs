using System.Windows;
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

            var multiChannel = ChannelReader.ReadFile(fileDialog.FileName);
            new NavBar(multiChannel) {Owner = this}
                .Show();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}