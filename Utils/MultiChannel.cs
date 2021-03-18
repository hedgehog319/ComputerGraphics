using System;
using System.Collections;

namespace ComputerGraphics.Utils
{
    public class MultiChannel<T>
    {
        private readonly Channel<T>[] _channels;
        private decimal _sampleRate;
        private DateTime _date;

        public MultiChannel(decimal sampleRate, DateTime date, int count)
        {
            _sampleRate = sampleRate;
            _date = date;
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