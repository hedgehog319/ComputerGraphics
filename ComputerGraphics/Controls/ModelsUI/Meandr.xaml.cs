using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class Meandr : UserControl,ISimulated
    {
        public Meandr()
        {
            InitializeComponent();
            parametr.Text = (WindowController.ChartModels.SamplesNumber / 8).ToString();
        }
        public List<double> Simulation()
        {
            int l = Convert.ToInt32(parametr.Text);
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                if (i % l < l/2 )
                {
                    list.Add(1);
                }
                else
                {
                    list.Add(-1);
                }
            }
            return list;
        }
    }
}