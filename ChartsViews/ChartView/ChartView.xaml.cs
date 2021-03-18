using System;

namespace ComputerGraphics.ChartsViews.ChartView
{
    public partial class ChartView : IDisposable
    {
        public ChartView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = (ChartViewModel) DataContext;
            vm.Values.Dispose();
        }
    }
}