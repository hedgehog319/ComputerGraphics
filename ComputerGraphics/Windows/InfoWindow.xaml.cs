using System.Windows;
using System.Windows.Input;

namespace ComputerGraphics.Windows
{
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();

            var models = WindowController.ChartModels;

            if (models?.OscillogramModels == null) return;

            ChannelNumber.Text += models.ChannelsNumber;
            SamplesNumber.Text += models.SamplesNumber;
            SamplingRate.Text += models.SamplingRate;
            StartTime.Text += models.StartTime;
            EndTime.Text += models.EndTime;
            Duration.Text += models.Duration;

            foreach (var model in models.OscillogramModels)
                Grid.Items.Add(new {model.Id, model.ChannelName, model.Source});
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}