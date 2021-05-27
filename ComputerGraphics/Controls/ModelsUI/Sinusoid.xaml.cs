using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class Sinusoid : UserControl,ISimulated
    {
        public Sinusoid()
        {
            InitializeComponent();
        }
        public List<double> Simulation()
        {
            double a = Convert.ToDouble(parametr.Text,CultureInfo.InvariantCulture);
            double om = Convert.ToDouble(parametr2.Text,CultureInfo.InvariantCulture);
            double fi = Convert.ToDouble(parametr3.Text,CultureInfo.InvariantCulture);
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
               list.Add(a * Math.Sin(i * om + fi));
            }
            return list;
        }
    }
}