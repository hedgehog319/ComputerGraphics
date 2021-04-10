using System;
using System.Collections.Generic;
using System.ComponentModel;
using ComputerGraphics.ChartsViews;

namespace ComputerGraphics.Windows.Oscillogram
{
    public class OscillogramModel : INotifyPropertyChanged
    {
        public readonly List<ChartModel> Charts = new();
        private const int MinCountDowns = 10;

        public double Maximum { get; private set; }

        public double Value
        {
            set
            {
                var range = Maximum * Range;
                foreach (var chart in Charts)
                {
                    if (value <= Maximum - range)
                        chart.From = value;

                    chart.To = value + range;
                }
            }
        }

        private double _range = 1;

        public double Range
        {
            get => _range;
            set
            {
                if (value is > 1 or <= 0) return;

                _range = value;

                Value = Charts[0].From;
                OnPropertyChanged(nameof(Size));
                OnPropertyChanged(nameof(ViewRange));
            }
        }

        public int ViewRange => Convert.ToInt32(Maximum * Range);

        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public double Size
        {
            get
            {
                IsVisible = true;
                var thumb = ActualWidth * Range;

                if (Math.Abs(Range - 1) < 0.001)
                {
                    thumb = ActualWidth - 1;
                    IsVisible = false;
                }

                var size = thumb * (Maximum - MinCountDowns) / (ActualWidth - thumb);

                // TODO maybe not need
                if (double.IsNaN(size) || double.IsInfinity(size))
                    size = ActualWidth * 1000;

                return size;
            }
        }

        private double _acWid;

        public double ActualWidth
        {
            get => _acWid;
            set
            {
                _acWid = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        public void Insert(ChartModel chartModel)
        {
            if (Charts.Contains(chartModel)) return;

            if (Charts.Count > 0)
            {
                chartModel.From = Charts[0].From;
                chartModel.To = Charts[0].To;
            }

            if (Maximum < chartModel.CountDowns)
                Maximum = chartModel.CountDowns;

            Charts.Add(chartModel);

            ItemInserted?.Invoke(chartModel);
        }

        public void Clear() => Charts.Clear();

        public delegate void ItemInsertHandler(ChartModel chartModel);

        public event ItemInsertHandler ItemInserted;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}