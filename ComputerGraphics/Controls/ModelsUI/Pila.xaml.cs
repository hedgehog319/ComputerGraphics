#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class Pila : UserControl, ISimulated
    {
        public Pila()
        {
            InitializeComponent();
            Parameter.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber / 8).ToString();
        }

        public List<double> Simulation()
        {
            var l = Convert.ToDouble(Parameter.Text, CultureInfo.InvariantCulture);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++) list.Add(i % l / l);

            return list;
        }
    }
}