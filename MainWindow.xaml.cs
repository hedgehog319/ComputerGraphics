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
        private MultiChannel<double> _channels;

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
            Tt = true;
            _channels = ChannelReader.ReadFile(fileDialog.FileName);
            new NavBar(_channels) {Owner = this}
                .Show();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("work");
        }

        public bool Tt { get; private set; } = false;

        private void Information_OnClick(object sender, RoutedEventArgs e)
        {
            var info = $"Текущее состояние многоканального сигнала\n" +
                       $"Общее число каналов - {_channels.CountChannels}\n" +
                       $"Общее количество отсчетов – {_channels.Countdowns}\n" +
                       $"Частота дискретизации – {_channels.SampleRate} Гц ( шаг между отсчетами {_channels.Period.ToString("F")} сек)\n" +
                       $"Дата и время начала записи - {_channels.StartDate}\n" +
                       $"Дата и время окончания записи - {_channels.EndDate} \n" +
                       $"Длительность: {_channels.Duration.Days} – суток, {_channels.Duration.Hours} – часов, {_channels.Duration.Minutes} – минут, {_channels.Duration.Seconds}.{_channels.Duration.Milliseconds} - секунд";
            //todo изменить вывод длительности 
            MessageBox.Show(info, "Информация");
        }
    }
}