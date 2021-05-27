using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DiscretizedDecreasingExponent : UserControl,ISimulated
    {
        public DiscretizedDecreasingExponent()
        {
            InitializeComponent();
        }
        
        public List<double> Simulation()
        {
            var a = Convert.ToDouble(parametr.Text,CultureInfo.InvariantCulture);
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
               list.Add(Math.Pow(a, i));
            }
            return list;
        }
        
    }
}