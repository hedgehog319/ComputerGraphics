using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class BalancedEnvelope : UserControl, ISimulated
    {
        public BalancedEnvelope()
        {
            InitializeComponent();
        }
        public List<double> Simulation()
        {
            var a = Convert.ToDouble(parametrA.Text,CultureInfo.InvariantCulture);
            var fo = Convert.ToDouble(parametrFO.Text,CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(parametrFi.Text,CultureInfo.InvariantCulture);
            var fn = Convert.ToDouble(parametrFN.Text,CultureInfo.InvariantCulture);
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                list.Add(a * Math.Cos(2*Math.PI*fo*i)*Math.Cos(2*Math.PI*fn*i+fi));
            }
            return list;
        }
    }
}