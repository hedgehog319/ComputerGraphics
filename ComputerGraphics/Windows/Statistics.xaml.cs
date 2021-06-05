using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ComputerGraphics.Charts;

namespace ComputerGraphics.Windows
{
    public partial class Statistics : Window
    {
        
        private double _aver, _disp, _deviation, _variation, _skewness, _kurt, _min, _max;
        public Statistics()
        {
            InitializeComponent();
            foreach (var model in WindowController.ChartModels)
            {
                box.Items.Add(model.ChannelName);
            }
        }

        private double FuncAverage(OscillogramModel model)
        {
            return _aver = (model.Values.Sum() / model.Values.Count);
        }

        private double FuncDispersion(OscillogramModel model)
        {
            return _disp = (model.Values.Sum(t => Math.Pow(t - _aver, 2))) / model.Values.Count;
        }

        private double FuncDeviation()
        {
            return _deviation = Math.Sqrt(_disp);
        }

        private double FuncVariation()
        {
            return _variation = _deviation / _aver;
        }

        private double FuncSkewness(OscillogramModel model)
        {
            return _skewness = (model.Values.Sum(t => Math.Pow(t - _aver, 3))) / (model.Values.Count*Math.Pow(_deviation, 3));
        }

        private double FuncKurtosis(OscillogramModel model)
        {
            return _kurt = ((model.Values.Sum(t => Math.Pow(t - _aver, 4))) / (model.Values.Count*Math.Pow(_deviation, 4))) - 3;
        }

        private double FuncMin(OscillogramModel model)
        {
            return _min = model.Values.Min();
        }
        
        private double FuncMax(OscillogramModel model)
        {
            return _max= model.Values.Max();
        }
        
        private void Box_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ComboBox comboBox) return;
            var model = WindowController.ChartModels[comboBox.SelectedIndex];
            Average.Text = FuncAverage(model).ToString();
            Dispersion.Text = FuncDispersion(model).ToString();
            StandardDeviation.Text = FuncDeviation().ToString();
            CoefficientVariation.Text = FuncVariation().ToString();
            SkewnessCoefficient.Text = FuncSkewness(model).ToString();
            KurtosisCoefficient.Text = FuncKurtosis(model).ToString();
            MinimumSignalValue.Text = FuncMin(model).ToString();
            MaximumSignalValue.Text = FuncMax(model).ToString();
        }
    }
}