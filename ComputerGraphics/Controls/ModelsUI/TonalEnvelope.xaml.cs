#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class TonalEnvelope : UserControl, ISimulated
    {
        public TonalEnvelope()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(ParameterA.Text, CultureInfo.InvariantCulture);
            var fo = Convert.ToDouble(ParameterF0.Text, CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(ParameterFi.Text, CultureInfo.InvariantCulture);
            var fn = Convert.ToDouble(ParameterFn.Text, CultureInfo.InvariantCulture);
            var m = Convert.ToDouble(ParameterM.Text, CultureInfo.InvariantCulture);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
                list.Add(a * (1 + m * Math.Cos(2 * Math.PI * fo * i)) * Math.Cos(2 * Math.PI * fn * i + fi));

            return list;
        }
    }
}