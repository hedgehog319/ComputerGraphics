using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Markup;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class NormalWhiteNoise : UserControl, ISimulated
    {
        private readonly Random _rand = new Random();
        public NormalWhiteNoise()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            if (!double.TryParse(TextMiddle.Text, out var middle) || middle < 0 ||
                !double.TryParse(TestSigma.Text, out var sigma) || sigma < 0)
            {
                return null;
            }
            
            var values = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                values.Add(middle + Math.Sqrt(sigma) * NormalRandomValue());
            }

            return values;
        }

        private double NormalRandomValue()
        {
            // Random _rand = new Random();
            double x = 0;
            for (var i = 0; i < 12; i++) x += _rand.NextDouble();

            return x - 6;
        }
    }
}