using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

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
            var a = Convert.ToDouble(parametrA.Text,CultureInfo.InvariantCulture);
            var fo = Convert.ToDouble(parametrFO.Text,CultureInfo.InvariantCulture);
            var fi = Convert.ToDouble(parametrFi.Text,CultureInfo.InvariantCulture);
            var fk = Convert.ToDouble(parametrFk.Text,CultureInfo.InvariantCulture);
            var T_nab = WindowController.ChartModels.SamplesNumber * WindowController.ChartModels.DeltaTime;
            var deltaF = (fk - fo) / T_nab;
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                var t = i * WindowController.ChartModels.DeltaTime;
                list.Add(a * Math.Cos(2 * Math.PI * (fo + deltaF * i) * i + fi));
            }


            return list;
        }
    }
}