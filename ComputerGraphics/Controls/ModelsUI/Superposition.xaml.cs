#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class Superposition : UserControl, ISimulated, INamed
    {
        private static int _id;
        private readonly List<int> _channels = new();
        private readonly List<double> _coefficients = new();

        public Superposition()
        {
            InitializeComponent();

            foreach (var model in WindowController.ChartModels)
            {
                ChannelsList.Items.Add(model);
                CoefList.Items.Add(new TextBox
                    {Text = "0", Width = 80, HorizontalAlignment = HorizontalAlignment.Center});
            }
        }

        public string GetName() => $"Суперпозиция {_id}";

        public List<double> Simulation()
        {
            try
            {
                for (var i = 0; i < ChannelsList.Items.Count; i++)
                    if (ChannelsList.SelectedItems.Contains(ChannelsList.Items[i]))
                    {
                        _channels.Add(i);
                        var coef = (TextBox) CoefList.Items[i];
                        _coefficients.Add(double.Parse(coef.Text));
                    }

                if (_channels.Count == 0) throw new Exception();
            }
            catch (Exception)
            {
                return null;
            }

            List<double> newChannel = new();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                double value = 0;
                try
                {
                    for (var j = 0; j < _channels.Count; j++)
                        value = value + _coefficients[j] * WindowController.ChartModels[j][i];
                }
                catch (OverflowException)
                {
                    value = value > 0 ? double.MaxValue : double.MinValue;
                }

                newChannel.Add(value);
            }

            _id++;
            return newChannel;
        }
    }
}