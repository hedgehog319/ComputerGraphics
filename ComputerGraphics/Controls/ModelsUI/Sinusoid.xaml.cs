#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class Sinusoid : UserControl, ISimulated
    {
        public Sinusoid()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(ParameterA.Text, CultureInfo.InvariantCulture);
            var om = Convert.ToDouble(ParameterOm.Text, CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(ParameterFi.Text, CultureInfo.InvariantCulture);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++) list.Add(a * Math.Sin(i * om + fi));
            return list;
        }
    }
}