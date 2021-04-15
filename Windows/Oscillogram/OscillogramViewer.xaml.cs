using System;
using System.Windows;
using System.Windows.Media;
using ComputerGraphics.ChartsViews;
using LiveCharts.Wpf;

namespace ComputerGraphics.Windows.Oscillogram
{
    public partial class OscillogramViewer : Window
    {
        private readonly OscillogramModel _model;

        public OscillogramViewer(OscillogramModel oscillogramModel)
        {
            InitializeComponent();

            _model = oscillogramModel;
            DataContext = _model;

            _model.ItemInserted += chartModel =>
                Panel.Children.Add(new ScrollView
                    {DataContext = chartModel, Height = 200, Margin = new Thickness(0, 0, 0, 5)});

            foreach (var chart in _model.Charts)
            {
                Panel.Children.Add(new ScrollView
                    {DataContext = chart, Height = 200, Margin = new Thickness(0, 0, 0, 5)});
            }
        }

        public OscillogramModel GetModel() => _model;

        private void Scroll_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _model.ActualWidth = Scroll.Track.ActualWidth;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            _model.Range /= 2;
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            _model.Range *= 2;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var chart in _model.Charts)
            {
                chart.Point = chart.Point == null ? DefaultGeometries.Circle : null;
            }
        }

        private void OscillogramViewer_OnClosed(object sender, EventArgs e) => _model.Clear();
    }
}