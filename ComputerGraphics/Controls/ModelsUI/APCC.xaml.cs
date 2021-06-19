#region

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class APCC : UserControl, ISimulated, INamed
    {
        private static int _id;
        private readonly Random _rand = new Random();

        public APCC()
        {
            InitializeComponent();
        }

        public string GetName() => $"АРСС {_id}";

        public List<double> Simulation()
        {
            try
            {
                var sigma = double.Parse(Sigma.Text);
                var p = int.Parse(PValue.Text);
                var q = int.Parse(QValue.Text);
                var aValues = Array.ConvertAll(ANumbers.Text.Replace('.', ',').Split(' '), double.Parse);
                var bValues = Array.ConvertAll(BNumbers.Text.Replace('.', ',').Split(' '), double.Parse);
                if (p != aValues.Length || q != bValues.Length)
                    throw new Exception();

                var yValues = new List<double>();
                var xValues = new List<double>();
                for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
                {
                    xValues.Add(NValue(sigma));
                    yValues.Add(xValues[i] + Sum(ref bValues, xValues) - Sum(ref aValues, yValues));
                }

                _id++;
                return yValues;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private double NValue(double sigma)
        {
            double x = 0;
            for (var i = 0; i < 12; i++) x += _rand.NextDouble();

            return (x - 6) * Math.Sqrt(sigma);
        }

        private double Sum(ref double[] factor, List<double> values)
        {
            double ans = 0;
            for (var i = 0; i < factor.Length && values.Count - i - 1 >= 0; i++)
                ans += factor[i] * values[values.Count - i - 1];

            return ans;
        }
    }
}