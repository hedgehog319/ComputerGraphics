using ComputerGraphics.Utils;
using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace ComputerGraphics.Windows
{
    public partial class testWindow : Window
    {
        public testWindow(Channel<double> ch)
        {
            InitializeComponent();

            var tt = new double[100];
            for (var i = 0; i < 100; i++)
            {
                tt[i] = ch[i];
            }
            Plot.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = ch.Name,
                    Values = new ChartValues<double>(tt),
                    Fill = Brushes.Transparent,
                    PointGeometry = null,
                },
                // new LineSeries
                // {
                //     Title = "Signal 2",
                //     Values = new ChartValues<ScatterPoint>
                //     {
                //         new ScatterPoint(5, 5),
                //         new ScatterPoint(3, 4),
                //         new ScatterPoint(7, 2),
                //     },
                //     Fill = Brushes.Transparent,
                //     PointGeometry = null,
                // }
            };
        }
    }
}