using System.Windows;
using ComputerGraphics.ChartsViews.ChartView;

namespace ComputerGraphics.Windows
{
    public partial class testWindow : Window
    {
        public testWindow()
        {
            InitializeComponent();
        }

        public testWindow(ChartViewModel model) : this()
        {
            Plot.DataContext = model;
        }
    }
}