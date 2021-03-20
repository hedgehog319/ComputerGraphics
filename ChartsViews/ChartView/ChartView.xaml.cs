using System;
using System.Windows.Input;
using ComputerGraphics.Windows;

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

        private void DelMe(object sender, MouseButtonEventArgs e)
        {
            var vm = (ChartViewModel) DataContext;
            new testWindow(vm).Show();
        }
    }
}