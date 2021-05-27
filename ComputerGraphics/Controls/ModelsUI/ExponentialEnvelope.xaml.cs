#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class ExponentialEnvelope : UserControl, ISimulated
    {
        public ExponentialEnvelope()
        {
            InitializeComponent();
            ParameterR.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber / 4).ToString();
            ParameterF.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber * 2).ToString();
        }

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(ParameterA.Text, CultureInfo.InvariantCulture);
            var r = Convert.ToDouble(ParameterR.Text, CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(ParameterFi.Text, CultureInfo.InvariantCulture);
            var f = Convert.ToDouble(ParameterF.Text, CultureInfo.InvariantCulture);
            
            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
                list.Add(a * Math.Exp(-i / r) * Math.Cos(2 * Math.PI * i * f + fi));
            
            return list;
        }
    }
}