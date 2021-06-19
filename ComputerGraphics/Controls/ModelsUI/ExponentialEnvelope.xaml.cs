#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class ExponentialEnvelope : UserControl, ISimulated, INamed
    {
        private static int _id;

        public ExponentialEnvelope()
        {
            InitializeComponent();
            ParameterR.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber / 4).ToString();
            ParameterF.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber * 2).ToString();
        }

        public string GetName() => $"Экп. огибающая {_id}";

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(ParameterA.Text, CultureInfo.InvariantCulture);
            var r = Convert.ToDouble(ParameterR.Text, CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(ParameterFi.Text, CultureInfo.InvariantCulture);
            var f = Convert.ToDouble(ParameterF.Text, CultureInfo.InvariantCulture);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                var t = i * WindowController.ChartModels.DeltaTime;
                list.Add(a * Math.Exp(-t / r) * Math.Cos(2 * Math.PI * t * f + fi));
            }

            _id++;
            return list;
        }
    }
}