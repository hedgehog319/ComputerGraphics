using System;
using System.Windows;
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
                var dataContext = new ChartViewModel(channel);
                var chartView = new ChartView
                {
                    DataContext = dataContext,
                    Height = 80
                };

                Bar.Children.Add(chartView);
            }
        }

        
    }
}