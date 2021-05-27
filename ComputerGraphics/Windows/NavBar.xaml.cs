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
        }

        public void AddOscillogram(int modelId)
        {
            Bar.Children.Add(new PreviewChart(WindowController.ChartModels[modelId])
                {Height = 80});
        }
    }
}