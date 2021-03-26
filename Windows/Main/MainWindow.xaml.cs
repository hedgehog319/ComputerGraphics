using System;
using System.Windows;
using System.Windows.Input;
using ComputerGraphics.Utils;

namespace ComputerGraphics.Windows.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowModel _data;
        private MultiChannel<double> _channels;

        public MainWindow()
        {
            InitializeComponent();

            _data = new MainWindowModel();
            DataContext = _data;
        }

        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            var msg = "Просграмма DSP позволяет визуализировать сигналы с различных устройств.\n" +
                      "Разработчики: Торжков А., Просин А., Антипов Д.";
            MessageBox.Show(msg, "О программе");
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (fileDialog.ShowDialog() != true) return;

            _data.IsFileOpen = true;
            _channels = ChannelReader.ReadFile(fileDialog.FileName);

            var navBar = new NavBar(_channels) {Owner = this};
            navBar.Closed += (o, args) => _data.IsNavBarOpen = false;
            navBar.Show();

            _data.IsNavBarOpen = false;

            // MessageBox.Show(_data.IsNavBarOpen.ToString());
        }

        private void Information_OnClick(object sender, RoutedEventArgs e)
        {
            var info = $"Текущее состояние многоканального сигнала\n" +
                       $"Общее число каналов - {_channels.CountChannels}\n" +
                       $"Общее количество отсчетов – {_channels.Countdowns}\n" +
                       $"Частота дискретизации – {_channels.SampleRate} Гц ( шаг между отсчетами {_channels.Period.ToString("F")} сек)\n" +
                       $"Дата и время начала записи - {_channels.StartDate}\n" +
                       $"Дата и время окончания записи - {_channels.EndDate}\n" +
                       $"Длительность: {_channels.Duration.Days} – суток, {_channels.Duration.Hours} – часов," +
                       $" {_channels.Duration.Minutes} – минут, {_channels.Duration.Seconds}.{_channels.Duration.Milliseconds} - секунд";
            //todo изменить вывод длительности 
            MessageBox.Show(info, "Информация");
        }

        private void OpenNavMenu_Click(object sender, RoutedEventArgs e)
        {
            if (_channels == null) return;

            new NavBar(_channels) {Owner = this}
                .Show();
        }
    }
}