using System;

namespace ComputerGraphics.ChartsViews
{
    public partial class ChartView : IDisposable
    {
        public ChartView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = DataContext as ChartModel;
            vm?.Values.Dispose();
        }

        public ChartModel GetModel => DataContext as ChartModel;
    }
}