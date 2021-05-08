#region

using System;
using System.Collections.Generic;

#endregion

namespace ComputerGraphics.Charts
{
    public class ChartModels
    {
        public ChartModels(int channelsNumber, int samplesNumber, double samplingRate, DateTime startTime,
            IReadOnlyList<List<double>> values, IReadOnlyList<string> channelsNames, string fileName)
        {
            ChannelsNumber = channelsNumber;
            SamplesNumber = samplesNumber;
            SamplingRate = samplingRate;
            StartTime = startTime;

            var duration = SamplesNumber / SamplingRate;
            EndTime = StartTime + TimeSpan.FromSeconds(duration);
            Duration = TimeSpan.FromSeconds(duration);

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

        public TimeSpan Duration { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }
        public List<OscillogramModel> OscillogramModels { get; }

        public double From
        {
            get => OscillogramModels[0].From;
            set
            {
                foreach (var model in OscillogramModels) model.From = value;
            }
        }

        public double To
        {
            get => OscillogramModels[0].To;
            set
            {
                foreach (var model in OscillogramModels) model.To = value;
            }
        }

        public int Range => Convert.ToInt32(To - From);

        public double Smoothness
        {
            get => OscillogramModels[0].Smoothness;
            set
            {
                foreach (var model in OscillogramModels) model.Smoothness = value;
            }
        }

        // TODO Point switcher
        public bool Point
        {
            get => OscillogramModels[0].SetPoint;
            set
            {
                foreach (var model in OscillogramModels) model.SetPoint = value;
            }
        }

        public OscillogramModel this[int i] => OscillogramModels[i];

        // TODO formatter
        public Func<double, string> Formatter { get; set; }
    }
}