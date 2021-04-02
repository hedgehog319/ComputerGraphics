using System.Windows;
using System.Windows.Input;
using ComputerGraphics.ChartsViews;
using ComputerGraphics.Utils;

namespace ComputerGraphics.Windows
{
    public partial class NavBar : Window
    {
        public NavBar(MultiChannel<double> channels)
        {
            InitializeComponent();

            foreach (Channel<double> channel in channels)
            {
                var dataContext = new ChartModel(channel);
                var chartView = new ChartView
                {
                    DataContext = dataContext,
                    Height = 80
                };

                Bar.Children.Add(chartView);
            }
        }

        // Remove it
        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ChartView view || view.GetModel == null) return;

            // new OscillogramViewer().Show();
            // OscillogramViewer.
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not ChartView view || view.GetModel == null) return;

            // WindowController.InsertChart(view.GetModel);
        }
    }
}