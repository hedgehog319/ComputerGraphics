#region

using System.Linq;
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
            if (Bar.Children.Cast<PreviewChart>().Any(chart => chart.GetModel.Id == modelId)) return;

            Bar.Children.Add(new PreviewChart(WindowController.ChartModels[modelId])
                {Height = 80});
        }
    }
}