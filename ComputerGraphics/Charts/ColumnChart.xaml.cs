#region

using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;

#endregion

namespace ComputerGraphics.Charts
{
    public partial class ColumnChart : UserControl
    {
        public ColumnChart()
        {
            InitializeComponent();
        }

        public ColumnChart(OscillogramModel model)
        {
            InitializeComponent();

            DataContext = model;
        }

        public void SetModel(OscillogramModel model)
        {
            // Values = model.Values;
            Series.Values = model.Values;
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        public GearedValues<double> Values { get; set; }

        public OscillogramModel GetModel => DataContext as OscillogramModel;

        public void Dispose() => GetModel?.Values.Dispose();
    }
}