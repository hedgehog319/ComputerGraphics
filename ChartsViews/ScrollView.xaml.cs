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

        public ScrollView()
        {
            InitializeComponent();
        }

        private void Axis_OnRangeChanged(RangeChangedEventArgs e)
        {
            GetModel.Range = Convert.ToInt32(e.Range);

            var currentRange = e.Range;
            GetModel.Formatter = currentRange switch
            {
                < TimeSpan.TicksPerDay * 2 => x => (_time + new TimeSpan((long) x)).ToString("t"),
                < TimeSpan.TicksPerDay * 60 => x => (_time + new TimeSpan((long) x)).ToString("dd MMM yy"),
                < TimeSpan.TicksPerDay * 540 => x => (_time + new TimeSpan((long) x)).ToString("MMM yy"),
                _ => x => (_time + new TimeSpan((long) x)).ToString("yyyy")
            };
        }

        public ChartModel GetModel => DataContext as ChartModel;

        public void Dispose() => GetModel?.Values.Dispose();
    }
}