#region

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
        private readonly Models _models;
        private const double MinOscillogramHeight = 200;

        public OscillogramViewer(Models models)
        {
            InitializeComponent();

            _models = models;

            Start.Text = _models.StartTime.ToString(CultureInfo.InvariantCulture);
            Range.Text = _models.Range.ToString();
            End.Text = _models.EndTime.ToString(CultureInfo.InvariantCulture);
        }

        public void AddOscillogram(int modelId)
        {
            if (Panel.Children.Cast<OscillogramChart>().Any(chart => chart.GetModel.Id == modelId)) return;

            Panel.Children.Add(new OscillogramChart(_models[modelId]));

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

            var t = -Math.Sign(e.Delta) * (_models.To - _models.From) / 2;
            _models.To += t;

            Range.Text = _models.Range.ToString();
            ChangeThumbSize(_models.Range);
        }

        private void ChangeThumbSize(int range)
        {
            var thumb = Scroll.ActualWidth * range / _models.SamplesNumber;
            Scroll.Maximum = _models.SamplesNumber - range;
            if (Scroll.Maximum < 10) return;

            var size = thumb * (Scroll.Maximum - 10) / (Scroll.ActualWidth - thumb);

            Scroll.ViewportSize = size;
        }

        private void Point_OnClick(object sender, RoutedEventArgs e)
        {
            _models.Point = !_models.Point;
        }

        private void Smoothness_OnClick(object sender, RoutedEventArgs e) =>
            _models.Smoothness = _models.Smoothness > 0 ? 0 : 1;

        private void Scroll_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is ScrollBar scroll)) return;

            var range = _models.Range;
            for (var i = 0; i < _models.ChannelsNumber; i++)
            {
                _models[i].From = scroll.Value;
                _models[i].To = scroll.Value + range;
            }
        }
    }
}