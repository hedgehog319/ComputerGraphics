using System;

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

        public void Dispose()
        {
            var vm = (ScrollableViewModel) DataContext;
            vm.Values.Dispose();
        }
    }
}