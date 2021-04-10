using System;
using LiveCharts.Events;

namespace ComputerGraphics.ChartsViews
{
    /// <summary>
    /// Interaction logic for ScrollingWindow.xaml
    /// </summary>
    public partial class ScrollView : IDisposable
    {
        private DateTime _time;
        private ChartModel _model;

        public ScrollView()
        {
            InitializeComponent();
            _model = DataContext as ChartModel;
            if (_model != null) return;

            _model = new ChartModel();
            DataContext = _model;
        }

        private void Axis_OnRangeChanged(RangeChangedEventArgs e)
        {
            var currentRange = e.Range;
            GetModel.Formatter = currentRange switch
            {
                < TimeSpan.TicksPerDay * 2 => x => (_time + new TimeSpan((long) x)).ToString("t"),
                < TimeSpan.TicksPerDay * 60 => x => (_time + new TimeSpan((long) x)).ToString("dd MMM yy"),
                < TimeSpan.TicksPerDay * 540 => x => (_time + new TimeSpan((long) x)).ToString("MMM yy"),
                _ => x => (_time + new TimeSpan((long) x)).ToString("yyyy")
            };
        }

        public ChartModel GetModel => _model;

        public void Dispose() => GetModel?.Values.Dispose();
    }
}