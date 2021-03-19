using System;
using System.Globalization;
using System.IO;

namespace ComputerGraphics.Utils
{
    public static class ChannelReader
    {
        public static MultiChannel<double> ReadFile(string path)
        {
            var extension = Path.GetExtension(path);
            return extension switch
            {
                ".txt" => ReadTxt(path),
                _ => null
            };
        }

        private static MultiChannel<double> ReadTxt(string path)
        {
            var file = File.ReadAllLines(path);
            var channels = int.Parse(file[1]);
            var countdowns = int.Parse(file[3]);
            var sampleRate = decimal.Parse(file[5], CultureInfo.InvariantCulture);
            var startDate = DateTime.Parse(file[7]);
            var names = file[11].Split(';');

            var multiChannel = new MultiChannel<double>(sampleRate, startDate, channels, countdowns);
            for (var i = 0; i < channels; i++)
                multiChannel[i] = new Channel<double>(names[i], countdowns);

            for (var i = 12; i < countdowns; i++)
            {
                var values = file[i].Split(' ');
                for (var j = 0; j < channels; j++)
                    multiChannel[j][i - 12] = double.Parse(values[j], CultureInfo.InvariantCulture);
            }

            return multiChannel;
        }
    }
}