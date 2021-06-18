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

        public Statistics()
        {
            InitializeComponent();
            foreach (var model in WindowController.ChartModels) box.Items.Add(model.ChannelName);
        }

        private double FuncAverage(BaseModel model)
        {
            return _aver = model.Values.Sum() / model.Values.Count;
        }

        private double FuncDispersion(BaseModel model)
        {
            return _dispersion = model.Values.Sum(t => Math.Pow(t - _aver, 2)) / model.Values.Count;
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
            return model.Values.Sum(t => Math.Pow(t - _aver, 3)) /
                   (model.Values.Count * Math.Pow(_deviation, 3));
        }

        private double FuncKurtosis(BaseModel model)
        {
            return model.Values.Sum(t => Math.Pow(t - _aver, 4)) /
                (model.Values.Count * Math.Pow(_deviation, 4)) - 3;
        }

        private void Box_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ComboBox comboBox) return;
            var model = WindowController.ChartModels[comboBox.SelectedIndex];

            Average.Text = FuncAverage(model).ToString(CultureInfo.InvariantCulture);
            Dispersion.Text = FuncDispersion(model).ToString(CultureInfo.InvariantCulture);
            StandardDeviation.Text = FuncDeviation().ToString(CultureInfo.InvariantCulture);
            CoefficientVariation.Text = FuncVariation().ToString(CultureInfo.InvariantCulture);
            SkewnessCoefficient.Text = FuncSkewness(model).ToString(CultureInfo.InvariantCulture);
            KurtosisCoefficient.Text = FuncKurtosis(model).ToString(CultureInfo.InvariantCulture);
            MinimumSignalValue.Text = model.Values.Min().ToString(CultureInfo.InvariantCulture);
            MaximumSignalValue.Text = model.Values.Max().ToString(CultureInfo.InvariantCulture);
        }
    }
}