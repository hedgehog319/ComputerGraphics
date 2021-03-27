using System;
using System.ComponentModel;
using ComputerGraphics.Utils;
using LiveCharts.Geared;

namespace ComputerGraphics.ChartsViews
{
    public class ChartModel : INotifyPropertyChanged
    {
        private Func<double, string> _formatter;
        private string _name;
        private double _from;
        private double _to;
        private double _smoothness;
        private int _range;

        public ChartModel()
        {
        }

        public ChartModel(Channel<double> ch)
        {
            // Formatter = x => new DateTime((long) x).ToString("yyyy");

            Values = ch.Values.AsGearedValues().WithQuality(Quality.Highest);
            Range = Values.Count;

            Name = ch.Name;
            From = 1;
            To = Values.Count - 1;
        }

        public GearedValues<double> Values { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public double From
        {
            get => _from;
            set
            {
                if (Math.Abs(To - Values.Count) < 0.000001)
                    return;
                _from = (value < 0) ? 0 : value;
                OnPropertyChanged(nameof(From));
            }
        }

        public double To
        {
            get => _to;
            set
            {
                var step = value - _to;
                if (From + step <= 0)
                    return;
                _to = (value > Values.Count) ? Values.Count : value;
                OnPropertyChanged(nameof(To));
            }
        }

        public double Smoothness
        {
            get => _smoothness;
            set
            {
                _smoothness = value;
                OnPropertyChanged(nameof(Smoothness));
            }
        }

        public int Range
        {
            get => _range;
            set
            {
                _range = (value < 0) ? 10 : value;
                OnPropertyChanged(nameof(Range));
            }
        }

        public Func<double, string> Formatter
        {
            get => _formatter;
            set
            {
                _formatter = value;
                OnPropertyChanged(nameof(Formatter));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}