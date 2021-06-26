#region

using System;
using System.Globalization;
using System.Windows;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class Statistics : Window
    {
        private double _aver, _dispersion, _deviation;
        private int _end;
        private int _start;

        private readonly BaseModel _model;

        public Statistics(OscillogramChart chart)
        {
            InitializeComponent();

            _model = chart.GetModel;
            Recalculate();
        }

        public void Recalculate()
        {
            _start = Convert.ToInt32(WindowController.ChartModels.From);
            _end = Convert.ToInt32(WindowController.ChartModels.To);

            Average.Text = FuncAverage(_model).ToString(CultureInfo.InvariantCulture);
            Dispersion.Text = FuncDispersion(_model).ToString(CultureInfo.InvariantCulture);
            StandardDeviation.Text = FuncDeviation().ToString(CultureInfo.InvariantCulture);
            CoefficientVariation.Text = FuncVariation().ToString(CultureInfo.InvariantCulture);
            SkewnessCoefficient.Text = FuncSkewness(_model).ToString(CultureInfo.InvariantCulture);
            KurtosisCoefficient.Text = FuncKurtosis(_model).ToString(CultureInfo.InvariantCulture);
            MinimumSignalValue.Text = FuncMin(_model).ToString(CultureInfo.InvariantCulture);
            MaximumSignalValue.Text = FuncMax(_model).ToString(CultureInfo.InvariantCulture);
            Quantile05.Text = Func05(_model).ToString(CultureInfo.InvariantCulture);
            Quantile95.Text = Func95(_model).ToString(CultureInfo.InvariantCulture);
            Median.Text = FuncMedian(_model).ToString(CultureInfo.InvariantCulture);
            FuncHisto(_model);
        }

        private double FuncAverage(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++) summ += model.Values[i];
            return _aver = summ / (_end - _start);
        }

        private double FuncDispersion(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++) summ += Math.Pow(model.Values[i] - _aver, 2);
            return _dispersion = summ / (_end - _start);
        }

        private double FuncDeviation()
        {
            return _deviation = Math.Sqrt(_dispersion);
        }

        private double FuncVariation()
        {
            return _deviation / _aver;
        }

        private double FuncSkewness(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++) summ += Math.Pow(model.Values[i] - _aver, 3);
            return summ / ((_end - _start) * Math.Pow(_deviation, 3));
        }

        private double FuncKurtosis(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++) summ += Math.Pow(model.Values[i] - _aver, 4);
            return summ / ((_end - _start) * Math.Pow(_deviation, 4)) - 3;
        }

        private double FuncMin(BaseModel model)
        {
            var min = model.Values[_start];
            for (var i = _start; i < _end; i++)
                if (model.Values[i] < min)
                    min = model.Values[i];

            return min;
        }

        private double FuncMax(BaseModel model)
        {
            var max = model.Values[_start];
            for (var i = _start + 1; i < _end; i++)
                if (model.Values[i] > max)
                    max = model.Values[i];

            return max;
        }

        private double[] Sort(BaseModel model)
        {
            var lenght = _end - _start;
            var mass = new double[lenght];
            for (var i = 0; i < lenght; i++) mass[i] = model.Values[_start + i];
            Array.Sort(mass);
            return mass;
        }

        private double Func05(BaseModel model)
        {
            var sortArray = Sort(model);
            return sortArray[Convert.ToInt32(0.05 * sortArray.Length)];
        }

        private double Func95(BaseModel model)
        {
            var sortArray = Sort(model);
            return sortArray[Convert.ToInt32(0.95 * sortArray.Length)];
        }

        private double FuncMedian(BaseModel model)
        {
            var sortArray = Sort(model);
            return sortArray[Convert.ToInt32(0.5 * sortArray.Length)];
        }

        private void FuncHisto(BaseModel model)
        {
            const int k = 15;
            var mass = new double[k];
            var min = FuncMin(model);

            var h = (FuncMax(model) - min) / k;


            for (var i = 0; i < k; i++)
            {
                var count = 0;
                for (var j = 0; j < _end - _start; j++)
                    if (model.Values[_start + j] >= min + i * h &&
                        model.Values[_start + j] <= min + (i + 1) * h)
                        count++;

                mass[i] = count;
            }

            Oscillogram.SetModel(new OscillogramModel(model.ChannelName, "123", mass));
        }
    }
}