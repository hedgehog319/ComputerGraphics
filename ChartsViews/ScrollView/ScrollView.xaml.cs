using System;
using System.Windows;
using System.Windows.Media;
using LiveCharts.Events;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace ComputerGraphics.ChartsViews.ScrollView
{
    /// <summary>
    /// Interaction logic for ScrollingWindow.xaml
    /// </summary>
    public partial class ScrollView : IDisposable
    {
        public ScrollView()
        {
            InitializeComponent();
        }

        private void Axis_OnRangeChanged(RangeChangedEventArgs e)
        {
            GetModel.Range = Convert.ToInt32(e.Range);

            // var vm = (ChartModel) DataContext;
            // var currentRange = e.Range;
            // vm.Formatter = currentRange switch
            // {
            //     < TimeSpan.TicksPerDay * 2 => x => new DateTime((long) x).ToString("t"),
            //     < TimeSpan.TicksPerDay * 60 => x => new DateTime((long) x).ToString("dd MMM yy"),
            //     < TimeSpan.TicksPerDay * 540 => x => new DateTime((long) x).ToString("MMM yy"),
            //     _ => x => new DateTime((long) x).ToString("yyyy")
            // };
        }

        public ChartModel GetModel => DataContext as ChartModel;

        public void Dispose() => GetModel?.Values.Dispose();
    }
}