using System.Collections;

namespace ComputerGraphics.Utils
{
    public class Channel<T>
    {
        private string _name;
        private T[] _countdown;

        public Channel()
        {
            _name = string.Empty;
            _countdown = null;
        }

        public Channel(string name, uint size)
        {
            _name = name;
            _countdown = new T[size];
        }

        public T this[int i]
        {
            get => _countdown[i];
            set => _countdown[i] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return _countdown.GetEnumerator();
        }
    }
}