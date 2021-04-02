using System;
using System.Collections.Generic;
using System.Windows;
using ComputerGraphics.ChartsViews;
using ComputerGraphics.ChartsViews.ScrollView;

namespace ComputerGraphics.Windows
{
    public partial class OscillogramViewer : Window
    {
        private static readonly List<ChartModel> _signal = new();

        public OscillogramViewer()
        {
            InitializeComponent();
        }

        public void Insert(ChartModel chartModel)
        {
            if (_signal.Contains(chartModel)) return;

            _signal.Add(chartModel);
            var scrollView = new ScrollView {DataContext = chartModel, Height = 250};
            Panel.Children.Add(scrollView);
        }

        private void OscillogramViewer_OnClosed(object? sender, EventArgs e) => _signal.Clear();
    }
}