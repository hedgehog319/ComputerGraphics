﻿using System;
using System.ComponentModel;
using ComputerGraphics.Utils;
using LiveCharts.Geared;

namespace ComputerGraphics.ChartsViews
{
    public sealed class ChartModel : INotifyPropertyChanged
    {
        private Func<double, string> _formatter;
        private string _name;
        private double _from;
        private double _to;
        private double _smoothness;

        public ChartModel()
        {
        }

        public ChartModel(Channel<double> ch)
        {
            Formatter = x => new DateTime((long) x).ToString("yyyy");

            Values = ch.Values.AsGearedValues().WithQuality(Quality.Highest);

            Name = ch.Name;
            From = 1;
            To = Values.Count - 1;
        }

        public GearedValues<double> Values { get; set; }

        public int CountDowns => Values.Count;

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
                _from = (value < 0) ? 0 : value;
                OnPropertyChanged(nameof(From));
            }
        }

        public double To
        {
            get => _to;
            set
            {
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

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}