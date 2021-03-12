using System.Collections;

namespace ComputerGraphics.Utils
{
    public class Channel<T>
    {
        private static uint _id = 0;
        private readonly T[] _values;

        public string Name { get; set; }

        private Channel()
        {
            Name = $"Канал {_id++}";
        }

        public Channel(string name, int countDowns) : this()
        {
            Name = name;
            _values = new T[countDowns];
        }

        public int CountDowns => _values.Length;

        public T this[int i]
        {
            get => _values[i];
            set => _values[i] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return _values.GetEnumerator();
        }
    }
}