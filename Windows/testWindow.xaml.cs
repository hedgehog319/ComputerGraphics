using System.Windows;
using ComputerGraphics.ChartsViews;

namespace ComputerGraphics.Windows
{
    public partial class testWindow : Window
    {
        public testWindow()
        {
            InitializeComponent();
        }

        public testWindow(ChartModel model) : this()
        {
            Plot.DataContext = model;
        }
    }
}