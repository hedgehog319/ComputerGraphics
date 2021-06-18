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
            BaseModel._absoluteId = 0; // TODO del me!

            ChannelsNumber = channelsNumber;
            SamplesNumber = samplesNumber;
            SamplingRate = samplingRate;
            DeltaTime = 1 / SamplingRate;
            StartTime = startTime;

            Duration = TimeSpan.FromSeconds(SamplesNumber / SamplingRate);

            OscillogramModels = new List<OscillogramModel>();

            for (var i = 0; i < channelsNumber; i++)
                OscillogramModels.Add(new OscillogramModel(channelsNames[i], fileName, values[i]));

            From = 1;
            To = OscillogramModels[0].Values.Count; // Check -1 needs?

            Formatter = x => StartTime.ToString("yyyy"); // it's ok?
        }

        public ChartModels(int samplesNumber, double samplingRate)
        {
            BaseModel._absoluteId = 0; // TODO del me!

            ChannelsNumber = 0;
            SamplesNumber = samplesNumber;
            SamplingRate = samplingRate;
            DeltaTime = 1 / SamplingRate;
            StartTime = DateTime.Now;

            Duration = TimeSpan.FromSeconds(SamplesNumber / SamplingRate);

            OscillogramModels = new List<OscillogramModel>();

            From = 1;
            To = 10; // Check -1 needs?

            Formatter = x => StartTime.ToString("yyyy"); // it's ok?
        }

        public int ChannelsNumber { get; private set; }
        public int SamplesNumber { get; } // кол-во отсчетов

        // частота дискретизации в Герцах: fd = 1/T, где T – шаг между отсчетами в секундах
        public double SamplingRate { get; }

        public double DeltaTime { get; }

        public TimeSpan Duration { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime => StartTime + Duration;
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

        public void Add(OscillogramModel model)
        {
            OscillogramModels.Add(model);
            ChannelsNumber++;
        }

        public IEnumerator<OscillogramModel> GetEnumerator() => OscillogramModels?.GetEnumerator();
    }
}