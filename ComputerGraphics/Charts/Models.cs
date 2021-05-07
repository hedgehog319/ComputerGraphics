#region

using System;
using System.Collections.Generic;

#endregion

namespace ComputerGraphics.Charts
{
    public class Models
    {
        public Models(int channelsNumber, int samplesNumber, double samplingRate, DateTime startTime,
            IReadOnlyList<List<double>> values, IReadOnlyList<string> channelsNames, string fileName)
        {
            ChannelsNumber = channelsNumber;
            SamplesNumber = samplesNumber;
            SamplingRate = samplingRate;
            StartTime = startTime;
            OscillogramModels = new List<OscillogramModel>();

            for (var i = 0; i < channelsNumber; i++)
                OscillogramModels.Add(new OscillogramModel(channelsNames[i], fileName, values[i]));

            From = 1;
            To = OscillogramModels[0].Values.Count; // Check -1 needs?

            StartTime = startTime;
            SamplingRate = samplingRate;

            Formatter = x => StartTime.ToString("yyyy"); // it's ok?
        }

        public int ChannelsNumber { get; }
        public int SamplesNumber { get; } // кол-во отсчетов

        // частота дискретизации в Герцах: fd = 1/T, где T – шаг между отсчетами в секундах
        public double SamplingRate { get; }

        public DateTime StartTime { get; }
        public List<OscillogramModel> OscillogramModels { get; }

        // TODO From setter
        public double From
        {
            set
            {
                foreach (var model in OscillogramModels) model.From = value;
            }
        }

        // TODO To setter
        public double To
        {
            set
            {
                foreach (var model in OscillogramModels) model.To = value;
            }
        }

        public double Smoothness
        {
            set
            {
                foreach (var model in OscillogramModels) model.Smoothness = value;
            }
        }

        // TODO Point switcher
        public bool Point
        {
            set
            {
                foreach (var model in OscillogramModels) model.SetPoint = value;
            }
        }

        // TODO redo formatter
        public Func<double, string> Formatter { get; set; }
    }
}