#region

using System.Windows;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class NavBar : Window
    {
        public NavBar()
        {
            InitializeComponent();

            foreach (var model in WindowController.ChartModels) Bar.Children.Add(new PreviewChart(model) {Height = 80});
        }
    }
}