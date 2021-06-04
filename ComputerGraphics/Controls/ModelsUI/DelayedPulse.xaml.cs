#region

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DelayedPulse : UserControl, ISimulated, INamed
    {
        private static int _id = 0;
        public DelayedPulse()
        {
            InitializeComponent();
            Parameter.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber * 0.3).ToString();
        }

        public List<double> Simulation()
        {
            var n0 = Convert.ToInt32(Parameter.Text);
            var list = new List<double>();
            for (var i = 0; i < WindowController.ChartModels.SamplesNumber; i++) list.Add(i < n0 ? 0 : 1);

            _id++;
            return list;
        }
        
        public string GetName() => $"Ед. скачок {_id}";
    }
}