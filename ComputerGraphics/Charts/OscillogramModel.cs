using System.Collections.Generic;
using System.Linq;
using ComputerGraphics.Signal;

namespace ComputerGraphics.Charts
{
    public class OscillogramModel
    {
        public double Max { get; }
        public double Min { get; }
        public string ChannelName { get; }
        public List<double> Values { get; }
        public OscillogramModel(Channel channel)
        {
            Min = channel.Values.Min();
            Max = channel.Values.Max();
            ChannelName = channel.Name;
            Values = channel.Values;
        }
    }
}