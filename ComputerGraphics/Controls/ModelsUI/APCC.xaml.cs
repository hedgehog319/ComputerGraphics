#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class APCC : UserControl, ISimulated, INamed
    {
        private readonly Random _rand = new Random();
        private static int _id = 0;

        public APCC()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            try
            {
                double sigma = Double.Parse(Sigma.Text);
                int p = Int32.Parse(PValue.Text);
                int q = Int32.Parse(QValue.Text);
                var aValues = Array.ConvertAll(ANumbers.Text.Split(' '), Double.Parse);
                var bValues = Array.ConvertAll(BNumbers.Text.Split(' '), Double.Parse);
                if (p != aValues.Length || q != bValues.Length)
                    throw new Exception();

                List<double> yValues = new List<double>();
                List<double> xValues = new List<double>();
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
        
        public string GetName() => $"АРСС {_id}";
    }
}