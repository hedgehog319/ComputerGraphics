#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DiscretizedDecreasingExponent : UserControl, ISimulated, INamed
    {
        private static int _id;

        public DiscretizedDecreasingExponent()
        {
            InitializeComponent();
        }

        public string GetName() => $"Убывающая экспонента {_id}";

        public List<double> Simulation()
        {
            var a = Convert.ToDouble(Parameter.Text, CultureInfo.InvariantCulture);
            var list = new List<double>();

            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
                list.Add(Math.Pow(a, i * WindowController.ChartModels.DeltaTime));

            _id++;
            return list;
        }
    }
}