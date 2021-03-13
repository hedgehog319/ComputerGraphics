using System;
using LiveCharts.Events;

namespace ComputerGraphics.ScrollView
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

        public void Dispose()
        {
            var vm = (ScrollableViewModel) DataContext;
            vm.Values.Dispose();
        }
    }
}