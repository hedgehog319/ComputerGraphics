using System.Windows;

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

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            // Console.WriteLine();
        }

        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            var msg = "Просграмма DSP позволяет визуализировать сигналы с различных устройств.\n" +
                      "Разработчики: Торжков А., Просин А., Антипов Д.";
            MessageBox.Show(msg, "О программе");
        }
    }
}