#region

using System;
using System.Globalization;
using System.Windows;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class ZoomBox : Window
    {
        public ZoomBox()
        {
            InitializeComponent();
            StartBox.Text = WindowController.ChartModels.From.ToString(CultureInfo.InvariantCulture);
            EndBox.Text = WindowController.ChartModels.To.ToString(CultureInfo.InvariantCulture);
        }

        public double From { get; private set; }
        public double To { get; private set; }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            From = Convert.ToDouble(StartBox.Text);
            To = Convert.ToDouble(EndBox.Text);

            DialogResult = true;
            Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e) => Close();
    }
}