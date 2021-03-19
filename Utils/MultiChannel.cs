using System;
using System.Collections;

namespace ComputerGraphics.Utils
{
    public class MultiChannel<T>
    {
        private readonly Channel<T>[] _channels;
        public decimal SampleRate { get; }
        public decimal Period { get; } // шаг между отсчетами
        public TimeSpan Duration { get; } //длительность
        public int Countdowns { get; } //количество отсчётов
        public DateTime StartDate { get; }

        public DateTime EndDate { get; }


        public int CountChannels
        {
            get => _channels.Length;
        }

        public MultiChannel(decimal sampleRate, DateTime startDate, int count, int countdowns)
        {
            SampleRate = sampleRate;
            Period = 1 / sampleRate;
            Countdowns = countdowns;
            var duration = Countdowns / sampleRate;
            StartDate = startDate;
            EndDate = StartDate + TimeSpan.FromSeconds((double) duration);
            Duration = TimeSpan.FromSeconds((double) duration);
            _channels = new Channel<T>[count];
        }


        public Channel<T> this[int i]
        {
            get => _channels[i];
            set => _channels[i] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return _channels.GetEnumerator();
        }
    }
}