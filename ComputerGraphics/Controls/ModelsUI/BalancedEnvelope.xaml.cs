#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class BalancedEnvelope : UserControl, ISimulated, INamed
    {
        private static int _id = 0;
        public BalancedEnvelope()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(ParameterA.Text, CultureInfo.InvariantCulture);
            var f0 = Convert.ToDouble(ParameterF0.Text, CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(ParameterFi.Text, CultureInfo.InvariantCulture);
            var fn = Convert.ToDouble(ParameterFn.Text, CultureInfo.InvariantCulture);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
                list.Add(a * Math.Cos(2 * Math.PI * f0 * i) * Math.Cos(2 * Math.PI * fn * i + fi));

            _id++;
            return list;
        }
        
        public string GetName() => $"Балансирующая огибающая {_id}";
    }
}