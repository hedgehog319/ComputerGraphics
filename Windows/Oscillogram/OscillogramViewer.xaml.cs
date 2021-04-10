﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using ComputerGraphics.ChartsViews;

namespace ComputerGraphics.Windows.Oscillogram
{
    public partial class OscillogramViewer : Window
    {
        private readonly OscillogramModel _model;

        public OscillogramViewer(OscillogramModel oscillogramModel)
        {
            InitializeComponent();

            _model = oscillogramModel;
            DataContext = _model;

            _model.ItemInserted += chartModel =>
                Panel.Children.Add(new ScrollView {DataContext = chartModel, Height = 200});

            foreach (var chart in _model.Charts)
            {
                Panel.Children.Add(new ScrollView {DataContext = chart, Height = 200});
            }
        }

        public OscillogramModel GetModel() => _model;

        private void OscillogramViewer_OnClosed(object sender, EventArgs e) => _model.Clear();

        private void Scroll_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void Scroll_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _model.ActualWidth = Scroll.Track.ActualWidth;
        }

        private double _thumb = 0;

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            _thumb += 0.1;
            _model.Range = _thumb;
        }
    }
}