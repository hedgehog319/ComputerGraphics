using System;
using System.ComponentModel;
using System.Globalization;
using ComputerGraphics.Utils;
using LiveCharts.Geared;

namespace ComputerGraphics.ChartsViews.ScrollView
{
    public class ScrollableViewModel : INotifyPropertyChanged
    {
        private Func<double, string> _formatter;
        private string _name;
        private double _from;
        private double _to;
        private double _smoothness;

        public ScrollableViewModel()
        {
        }

        public ScrollableViewModel(Channel<double> ch)
        {
            Formatter = x => x.ToString(CultureInfo.InvariantCulture);

            Values = ch.Values.AsGearedValues().WithQuality(Quality.Medium);

            Name = ch.Name;

            Formatter = x => new DateTime((long) x).ToString("yyyy");
            From = 0;
            To = Values.Count;
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
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        public double To
        {
            get => _to;
            set
            {
                _to = value;
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