using System.Windows;
using System.Windows.Input;
using ComputerGraphics.ChartsViews;
using ComputerGraphics.ChartsViews.ChartView;
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

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ChartView view) return;
            if (view.GetModel != null)
                new testWindow(view.GetModel) {Owner = this.Owner}.Show();
        }
    }
}