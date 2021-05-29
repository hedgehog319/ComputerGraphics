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
            foreach (var chartModel in WindowController.ChartModels)
                Bar.Children.Add(new PreviewChart(chartModel) {Height = 80});
        }

        public void AddOscillogram(int modelId)
        {
            Bar.Children.Add(new PreviewChart(WindowController.ChartModels[modelId])
                {Height = 80});
        }
    }
}