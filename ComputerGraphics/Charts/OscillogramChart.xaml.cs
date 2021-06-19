#region

using System;
using System.Windows;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Charts
{
    public partial class OscillogramChart : IDisposable
    {
        public OscillogramChart()
        {
            InitializeComponent();
        }
        public OscillogramChart(OscillogramModel model)
        {
            InitializeComponent();

            DataContext = model;
        }

        public OscillogramModel GetModel => DataContext as OscillogramModel;

        public void Dispose() => GetModel?.Values.Dispose();

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.RemoveFromViewer(this);
        }

        private void Statistic_OnClick(object sender, RoutedEventArgs e)
        {
            WindowController.ShowStatistics(this);
        }
    }
}