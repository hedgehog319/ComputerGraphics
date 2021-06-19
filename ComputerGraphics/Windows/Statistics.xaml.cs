#region

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ComputerGraphics.Charts;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class Statistics : Window
    {
        private double _aver, _dispersion, _deviation;
        private int _start = Convert.ToInt32(WindowController.ChartModels.From);
        private int _end = Convert.ToInt32(WindowController.ChartModels.To);


        public Statistics(OscillogramChart chart)
        {
            InitializeComponent();
            var model = chart.GetModel;

            Average.Text = FuncAverage(model).ToString(CultureInfo.InvariantCulture);
            Dispersion.Text = FuncDispersion(model).ToString(CultureInfo.InvariantCulture);
            StandardDeviation.Text = FuncDeviation().ToString(CultureInfo.InvariantCulture);
            CoefficientVariation.Text = FuncVariation().ToString(CultureInfo.InvariantCulture);
            SkewnessCoefficient.Text = FuncSkewness(model).ToString(CultureInfo.InvariantCulture);
            KurtosisCoefficient.Text = FuncKurtosis(model).ToString(CultureInfo.InvariantCulture);
            MinimumSignalValue.Text = FuncMin(model).ToString(CultureInfo.InvariantCulture);
            MaximumSignalValue.Text = FuncMax(model).ToString(CultureInfo.InvariantCulture);
            Quantile05.Text = Func05(model).ToString(CultureInfo.InvariantCulture);
            Quantile95.Text = Func95(model).ToString(CultureInfo.InvariantCulture);
            Median.Text = FuncMedian(model).ToString(CultureInfo.InvariantCulture);
        }

        private double FuncAverage(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++)
            {
                summ += model.Values[i];
            }
            return _aver = summ/(_end - _start);
        }

        private double FuncDispersion(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++)
            {
                summ += Math.Pow(model.Values[i] - _aver, 2);
            }
            return _dispersion = summ/(_end - _start);
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
            for (var i = _start; i < _end; i++)
            {
                summ += Math.Pow(model.Values[i] - _aver, 3);
            }
            return summ/((_end - _start) * Math.Pow(_deviation, 3));
        }

        private double FuncKurtosis(BaseModel model)
        {
            double summ = 0;
            for (var i = _start; i < _end; i++)
            {
                summ += Math.Pow(model.Values[i] - _aver, 4);
            }
            return summ/((_end - _start) * Math.Pow(_deviation, 4))-3;
        }

        private double FuncMin(BaseModel model)
        {
            double min = model.Values[_start];
            for (var i = _start + 1; i < _end; i++)
            {
                if (model.Values[i] < min) min = model.Values[i];
            }

            return min;
        }
        
        private double FuncMax(BaseModel model)
        {
            double max = model.Values[_start];
            for (var i = _start + 1; i < _end; i++)
            {
                if (model.Values[i] > max) max = model.Values[i];
            }

            return max;
        }

        private double[] Sort(BaseModel model)
        {
            var lenght = _end - _start;
            double[] mass = new double[lenght];
            for (int i = 0; i < lenght; i++)
            {
                mass[i] = model.Values[_start + i];
            }
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
            var k = 15;
            double[] mass = new double[k];
            var h = Math.Round((FuncMax(model) - FuncMin(model)) / k);
            for (int i = 0; i < k; i++)
            {
                var count = 0;
                for (int j = 0; j < (_end - _start); j++)
                {
                    if (model.Values[j] >= (+FuncMin(model) + i * h) &&
                        model.Values[j] <= (+FuncMin(model) + (i + 1) * h)) count++;
                }

                mass[i] = count;
            }

            var model_ = new OscillogramModel("123", "123", mass);
            Oscillogram.DataContext = model_;
        }

        
    }
}