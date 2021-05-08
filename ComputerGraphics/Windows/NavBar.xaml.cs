#region

using System.Windows;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class NavBar : Window
    {
        public NavBar(ChartModels chartModels)
        {
            InitializeComponent();

            foreach (var model in chartModels.OscillogramModels) Bar.Children.Add(new PreviewChart(model) {Height = 80});
        }
    }
}