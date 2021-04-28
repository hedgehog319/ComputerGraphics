using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ComputerGraphics.Signal;
using System.Windows.Media;

namespace ComputerGraphics.Charts
{
    public class Models : INotifyPropertyChanged
    {
        private double _from;
        private double _to;
        private double _smoothness;
        private Geometry _point; // = null;   надо ли?
        private Func<double, string> _formatter;

        public DateTime StartTime { get; }
        public double SamplingRate { get; }
        public List<OscillogramModel> OscillogramModels { get; }


        public Models(MultiChannel multiChannel)
        {
            foreach (var channel in multiChannel.Channels)
            {
                OscillogramModels.Add(new OscillogramModel(channel));
            }
            
            From = 1;
            To = OscillogramModels[0].Values.Count - 1;
            StartTime = multiChannel.StartTime;
            SamplingRate = multiChannel.SamplingRate;
            Formatter = x => StartTime.ToString("yyyy");  // it's ok?
        }

        public double From
        {
            get => _from;
            set
            {
                _from = value;  // todo change this
                OnPropertyChanged(nameof(From));
            }
        }

        public double To
        {
            get => _to;
            set
            {
                _to = value;  // todo change this
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
        public Geometry Point
        {
            get => _point;
            set
            {
                _point = value;
                OnPropertyChanged(nameof(Point));
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}