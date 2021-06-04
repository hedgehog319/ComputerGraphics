using System;
using System.Collections.Generic;
using System.Windows;
using ComputerGraphics.Charts;

namespace ComputerGraphics.Windows
{
    public partial class SaveWindow : Window
    {
        public int From { get; private set; }
        public int To { get; private set; }

        public int ChannelsNumber { get; private set; }

        public List<int> Channels { get; } = new();

        public SaveWindow()
        {
            InitializeComponent();

            foreach (var model in WindowController.ChartModels)
                ChannelsList.Items.Add(model);
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            if (ChannelsList.SelectedItems.Count == 0 && AllSignals.IsChecked != true)
            {
                var res = MessageBox.Show("Вы не выбрали ни одного сигнала. Хртите закрыть окно?",
                    "Внимание!", MessageBoxButton.YesNo);

                if (res != MessageBoxResult.Yes) return;

                DialogResult = false;
                Close();
                return;
            }

            if (AllSignal.IsChecked == true)
            {
                From = 0;
                To = WindowController.ChartModels.SamplesNumber;
            }
            else
            {
                From = Convert.ToInt32(FromBox.Text);
                To = Convert.ToInt32(ToBox.Text);
            }

            if (AllSignals.IsChecked != true)
                foreach (OscillogramModel item in ChannelsList.SelectedItems)
                {
                    Channels.Add(item.Id);
                    ChannelsNumber++;
                }
            else
            {
                for (var i = 0; i < WindowController.ChartModels.ChannelsNumber; i++)
                    Channels.Add(i);

                ChannelsNumber = WindowController.ChartModels.ChannelsNumber;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void All_OnChecked(object sender, RoutedEventArgs e)
        {
            FromBox.IsEnabled = false;
            ToBox.IsEnabled = false;
        }

        private void All_OnUnchecked(object sender, RoutedEventArgs e)
        {
            FromBox.IsEnabled = true;
            ToBox.IsEnabled = true;
        }
    }
}