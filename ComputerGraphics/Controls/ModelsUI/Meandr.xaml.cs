#region

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class Meandr : UserControl, ISimulated, INamed
    {
        private static int _id = 0;
        public Meandr()
        {
            InitializeComponent();
            Parameter.Text = (WindowController.ChartModels.SamplesNumber / 8).ToString();
        }

        public List<double> Simulation()
        {
            var l = Convert.ToInt32(Parameter.Text);

            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++) list.Add(i % l < l / 2 ? 1 : -1);

            _id++;
            return list;
        }
        
        public string GetName() => $"Меандр {_id}";
    }
}