using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class ExponentialEnvelope : UserControl, ISimulated
    {
        public ExponentialEnvelope()
        {
            InitializeComponent();
            parametrR.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber / 4).ToString();
            parametrF.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber * 2).ToString();
        }
        public List<double> Simulation()
        {
            var a = Convert.ToDouble(parametrA.Text,CultureInfo.InvariantCulture);
            var r = Convert.ToDouble(parametrR.Text,CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(parametrFi.Text,CultureInfo.InvariantCulture);
            var f = Convert.ToDouble(parametrF.Text,CultureInfo.InvariantCulture);
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                list.Add(a * Math.Exp(-i/r)*Math.Cos(2*Math.PI*i*f+fi));
            }
            return list;
        }
    }
}