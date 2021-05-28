#region

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class APCC : UserControl, ISimulated
    {
        private readonly Random _rand = new Random();
        private readonly List<double> values = new List<double>();

        public APCC()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            double sigma = 0;
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++) values.Add(NValue(sigma));

            return values;
        }

        private double NValue(double sigma)
        {
            double x = 0;
            for (var i = 0; i < 12; i++) x += _rand.NextDouble();

            return (x - 6) * Math.Sqrt(sigma);
        }

        private double QSum(List<double> B, List<double> X)
        {
            double value = 0;
            for (var i = 0; i < B.Count && X.Count - i >= 0; i++) value += B[i] * X[X.Count - i];

            return value;
        }
    }
}