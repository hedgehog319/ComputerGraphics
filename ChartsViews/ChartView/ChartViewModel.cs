﻿using System.ComponentModel;
using ComputerGraphics.Utils;
using LiveCharts.Geared;

namespace ComputerGraphics.ChartsViews.ChartView
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        private string _name;
        private double _from;
        private double _to;
        private double _smoothness;

        public ChartViewModel()
        {
        }

        public ChartViewModel(Channel<double> ch)
        {
            Values = ch.Values.AsGearedValues().WithQuality(Quality.Highest);

            Name = ch.Name;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}