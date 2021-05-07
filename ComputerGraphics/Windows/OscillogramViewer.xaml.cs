#region

using System.Windows;
using System.Windows.Input;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class OscillogramViewer : Window
    {
        private const double minOscillogramHeight = 200;

        public OscillogramViewer()
        {
            InitializeComponent();
        }

        public void AddOscillogram(OscillogramModel model)
        {
            Panel.Children.Add(new OscillogramChart(model));
            var height = (this.Height - 40) / Panel.Children.Count > 200 ? this.Height / Panel.Children.Count - 40 : 200;

            foreach (OscillogramChart chart in Panel.Children) chart.Height = height;
        }

        private void OscillogramViewer_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var height = (this.Height - 40) / Panel.Children.Count > 200 ? this.Height / Panel.Children.Count - 40 : 200;
            foreach (OscillogramChart chart in Panel.Children) chart.Height = height;
        }
    }
}