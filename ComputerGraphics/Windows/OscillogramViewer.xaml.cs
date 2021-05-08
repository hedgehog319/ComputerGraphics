﻿#region

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class OscillogramViewer : Window
    {
        private readonly ChartModels _chartModels;
        private const double MinOscillogramHeight = 200;

        public OscillogramViewer(ChartModels chartModels)
        {
            InitializeComponent();

            _chartModels = chartModels;

            Start.Text = _chartModels.StartTime.ToString(CultureInfo.InvariantCulture);
            Range.Text = _chartModels.Range.ToString();
            End.Text = _chartModels.EndTime.ToString(CultureInfo.InvariantCulture);
        }

        public void AddOscillogram(int modelId)
        {
            if (Panel.Children.Cast<OscillogramChart>().Any(chart => chart.GetModel.Id == modelId)) return;

            Panel.Children.Add(new OscillogramChart(_chartModels[modelId]));

            var height = Panel.ActualHeight / Panel.Children.Count;
            if (height < MinOscillogramHeight) height = MinOscillogramHeight;

            foreach (OscillogramChart chart in Panel.Children) chart.Height = height;
        }

        private void OscillogramViewer_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var height = Panel.ActualHeight / Panel.Children.Count;
            if (height < MinOscillogramHeight) height = MinOscillogramHeight;

            foreach (OscillogramChart chart in Panel.Children) chart.Height = height;
        }

        private void OscillogramViewer_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!Keyboard.IsKeyDown(Key.LeftCtrl)) return;

            e.Handled = true;

            var t = -Math.Sign(e.Delta) * (_chartModels.To - _chartModels.From) / 2;
            _chartModels.To += t;

            Range.Text = _chartModels.Range.ToString();
            ChangeThumbSize(_chartModels.Range);
        }

        private void ChangeThumbSize(int range)
        {
            var thumb = Scroll.ActualWidth * range / _chartModels.SamplesNumber;
            Scroll.Maximum = _chartModels.SamplesNumber - range;
            if (Scroll.Maximum < 10) return;

            var size = thumb * (Scroll.Maximum - 10) / (Scroll.ActualWidth - thumb);

            Scroll.ViewportSize = size;
        }

        private void Point_OnClick(object sender, RoutedEventArgs e)
        {
            _chartModels.Point = !_chartModels.Point;
        }

        private void Smoothness_OnClick(object sender, RoutedEventArgs e) =>
            _chartModels.Smoothness = _chartModels.Smoothness > 0 ? 0 : 1;

        private void Scroll_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is ScrollBar scroll)) return;

            var range = _chartModels.Range;
            for (var i = 0; i < _chartModels.ChannelsNumber; i++)
            {
                _chartModels[i].From = scroll.Value;
                _chartModels[i].To = scroll.Value + range;
            }
        }
    }
}