﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DelayedPulse : UserControl, ISimulated
    {
        public DelayedPulse()
        {
            InitializeComponent();
            parametr.Text = Convert.ToInt32(WindowController.ChartModels.SamplesNumber * 0.3).ToString();
        }

        public List<double> Simulation()
        {
            int n0 = Convert.ToInt32(parametr.Text);
            var list = new List<double>();
            for (int i = 0; i < WindowController.ChartModels.SamplesNumber; i++)
            {
                if (i < n0)
                {
                    list.Add(0);
                }
                else
                {
                    list.Add(1);
                }
            }

            return list;
        }
    }
}