#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class LChM : UserControl, ISimulated
    {
        public LChM()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(ParameterA.Text, CultureInfo.InvariantCulture);
            var f0 = Convert.ToDouble(ParameterF0.Text, CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(ParameterFi.Text, CultureInfo.InvariantCulture);
            var fk = Convert.ToDouble(ParameterFk.Text, CultureInfo.InvariantCulture);
            var deltaF = (fk - f0) /
                         (WindowController.ChartModels.SamplesNumber * WindowController.ChartModels.DeltaTime);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                var t = i * WindowController.ChartModels.DeltaTime;
                list.Add(a * Math.Cos(2 * Math.PI * (f0 + deltaF * t) * t + fi));
            }

            return list;
        }
    }
}