﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ComputerGraphics.Charts;
using ComputerGraphics.Controls.ModelsUI;

namespace ComputerGraphics.Windows
{
    public partial class Simulator : Window
    {
        private readonly SimulatorModel _model;

        public Simulator()
        {
            InitializeComponent();
            _model = DataContext as SimulatorModel;

            ComboBox.ItemsSource =
                (from SimulatorModel.Simulations value in Enum.GetValues(typeof(SimulatorModel.Simulations))
                    let fi = value.GetType().GetField(value.ToString())
                    let attr = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    select attr.Length > 0 ? attr[0].Description : value.ToString()).ToList();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Selector_OnSelected(object sender, RoutedEventArgs e)
        {
            if (sender is not ComboBox comboBox) return;

            _model.ChangeView((SimulatorModel.Simulations) comboBox.SelectedIndex);
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO change name and source
            var view = _model.View as ISimulated;
            var simulation = view?.Simulation();

            var oscillogramModel = new OscillogramModel("name", "Sim_Name", simulation);
            WindowController.ChartModels.Add(oscillogramModel);

            WindowController.AddOscillogram(oscillogramModel.Id);
            // Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e) => Close();
    }
}