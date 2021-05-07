﻿#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiveCharts.Geared;

#endregion

namespace ComputerGraphics.Charts
{
    public class BaseModel : INotifyPropertyChanged
    {
        private string _channelName;
        private double _from;
        private double _to;

        public BaseModel()
        {
        }

        protected BaseModel(string name, string source, IEnumerable<double> values)
        {
            Values = values.AsGearedValues().WithQuality(Quality.Highest);
            ChannelName = name;
            Source = source;

            From = 0;
            To = Values.Count;
        }

        public string Source { get; }

        public double From
        {
            get => _from;
            set
            {
                if (Equals(_from, value)) return;

                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        public double To
        {
            get => _to;
            set
            {
                if (Equals(_to, value)) return;

                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        public string ChannelName
        {
            get => _channelName;
            set
            {
                if (Equals(_channelName, value)) return;

                _channelName = value;
                OnPropertyChanged(nameof(ChannelName));
            }
        }

        public GearedValues<double> Values { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}