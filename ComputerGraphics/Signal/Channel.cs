using System.Collections.Generic;

namespace ComputerGraphics.Signal
{
    public class Channel
    {
        public string Name { get; }
        public string Source { get; }  // источник канала
        public List<double> Values { get; }

        public Channel(string name, string source, List<double> values)
        {
            Name = name;
            Source = source;
            Values = values;
        }
    }
}