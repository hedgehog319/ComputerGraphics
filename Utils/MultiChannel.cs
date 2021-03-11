using System;

namespace ComputerGraphics.Utils
{
    public class MultiChannel<T>
    {
        private Channel<T>[] _channels;
        private decimal _sampleRate;
        private DateTime _date;

        public MultiChannel(decimal sampleRate, DateTime date, uint count)
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
    }
}