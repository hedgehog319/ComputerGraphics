#region

using System.Windows;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class NavBar : Window
    {
        public NavBar(Models models)
        {
            InitializeComponent();

            foreach (var model in models.OscillogramModels) Bar.Children.Add(new PreviewChart(model) {Height = 80});
        }
    }
}