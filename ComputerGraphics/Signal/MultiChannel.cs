using System;
using System.Collections.Generic;

namespace ComputerGraphics.Signal
{
    public class MultiChannel
    {
        public int ChannelsNumber { get; private set; }
        public int SamplesNumber { get; }  // кол-во отсчетов
        
        // частота дискретизации в Герцах: fd = 1/T, где T – шаг между отсчетами в секундах
        public double SamplingRate { get; } 

        public DateTime StartTime { get; private set; }
        public List<Channel> Channels { get; private set; }


        // TODO подумать в чем хранить startTime (может быть в timestamp?)
        public MultiChannel(int channelsNumber, int samplesNumber, double samplingRate, DateTime startTime,
            List<List<double>> values, List<string> channelsNames, string fileName)
        {
            ChannelsNumber = channelsNumber;
            SamplesNumber = samplesNumber;
            SamplingRate = samplingRate;
            StartTime = startTime;
            Channels = new List<Channel>();

            for (int i = 0; i < channelsNumber; i++)
            {
                Channels.Add(new Channel(channelsNames[i], fileName, values[i]));
            }
        }
    }
}