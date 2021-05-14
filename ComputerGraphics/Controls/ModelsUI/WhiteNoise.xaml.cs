using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class WhiteNoise : UserControl, ISimulated
    {
        public WhiteNoise()
        {
            InitializeComponent();
        }
        
        private void TextBoxBase_OnTextChanged(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            if (sender is not TextBox textBox) return;
        }

        public List<double> Simulation()
        {
            if (!double.TryParse(TextA.Text, out var numberA) || numberA < 0 ||
                !double.TryParse(TextB.Text, out var numberB) || numberB < 0)
            {
                return null;
            }

            var rand = new Random();
            var values = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                values.Add(numberA + (numberB - numberA) * rand.NextDouble());
            }
            
            return values;
        }
    }
}