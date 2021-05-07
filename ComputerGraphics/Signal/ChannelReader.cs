#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Signal
{
    public static class ChannelReader
    {
        public static Models ReadTxt(string path)
        {
            var fileName = Path.GetFileName(path);
            var channelsNumber = 0;
            var samplesNumber = 0;
            var samplingRate = 0.0;
            var startDate = new DateTime();
            var startTime = new DateTime();
            var channelsNames = new List<string>();
            var values = new List<List<double>>();

            using (var stream = new StreamReader(path))
            {
                for (var i = 0; i < 12; i++)
                {
                    var line = stream.ReadLine();
                    if (line == null) throw new FileLoadException("Incorrect head format");

                    if (line.Contains("#")) continue;

                    // ReSharper disable once ConvertIfStatementToSwitchStatement
                    if (i == 1) channelsNumber = Convert.ToInt32(line);
                    if (i == 3) samplesNumber = Convert.ToInt32(line);
                    if (i == 5) samplingRate = Convert.ToDouble(line, CultureInfo.InvariantCulture);
                    if (i == 7) startDate = Convert.ToDateTime(line);
                    if (i == 9) startTime = Convert.ToDateTime(line);
                    if (i == 11) channelsNames = new List<string>(line.Split(';'));
                }

                for (var i = 0; i < channelsNumber; i++)
                {
                    values.Add(new List<double>(samplesNumber));
                    values[i].AddRange(new double[samplesNumber]); // Solve issue with memory allocation
                }


                for (var i = 0; i < samplesNumber; i++)
                {
                    var val = stream.ReadLine()?.Split(' ');
                    if (val == null) throw new FileLoadException("Incorrect data format");

                    for (var j = 0; j < val.Length - 1; j++)
                        // if (!string.IsNullOrEmpty(val[j]))
                        values[j][i] = Convert.ToDouble(val[j], CultureInfo.InvariantCulture);
                }
            }

            // CHECK maybe better store data and time separate?
            startTime = startDate.Add(startTime.TimeOfDay); // TODO addition date and time

            return new Models(channelsNumber, samplesNumber, samplingRate,
                startTime, values, channelsNames, fileName);
        }
    }
}