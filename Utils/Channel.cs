using System.Collections;

namespace ComputerGraphics.Utils
{
    public class Channel<T>
    {
        private static uint _id = 0;

        public string Name { get; }

        private Channel()
        {
            Name = $"Канал {_id++}";
        }

        public Channel(string name, int countDowns) : this()
        {
            Name = name;
            Values = new T[countDowns];
        }

        public int CountDowns => Values.Length;

        public T this[int i]
        {
            get => Values[i];
            set => Values[i] = value;
        }

        public T[] Values { get; }

        public IEnumerator GetEnumerator()
        {
            return Values.GetEnumerator();
        }
    }
}