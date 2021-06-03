#region

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class WhiteNoise : UserControl, ISimulated
    {
        public WhiteNoise()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            if (!double.TryParse(TextA.Text, out var numberA) ||
                !double.TryParse(TextB.Text, out var numberB))
                return null;

            var rand = new Random();
            var values = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
                values.Add(numberA + (numberB - numberA) * rand.NextDouble());

            return values;
        }

        private void TextBoxBase_OnTextChanged(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            if (sender is not TextBox textBox) return;
        }
    }
}