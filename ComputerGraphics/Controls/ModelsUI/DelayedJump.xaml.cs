﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ComputerGraphics.Charts;
using ComputerGraphics.Windows;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DelayedJump : UserControl, ISimulated
    {
        public DelayedJump()
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
                if (i == n0)
                {
                    list.Add(1);
                }
                else
                {
                    list.Add(0);
                }
            }

            return list;
        }
    }
}