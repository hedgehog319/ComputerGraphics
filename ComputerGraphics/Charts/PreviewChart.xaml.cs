#region

using System;
using System.Windows;
using System.Windows.Controls;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics.Charts
{
    public partial class PreviewChart : UserControl
    {
        public PreviewChart(BaseModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Oscillogram_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is BaseModel model)) throw new ArgumentException("Model is null");

            WindowController.AddOscillogram(model);
        }
    }
}