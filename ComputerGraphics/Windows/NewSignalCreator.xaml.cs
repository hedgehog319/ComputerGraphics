#region

using System;
using System.Globalization;
using System.Windows;

#endregion

namespace ComputerGraphics.Windows
{
    public partial class NewSignalCreator : Window
    {
        public NewSignalCreator()
        {
            InitializeComponent();
        }

        public int SamplesNumber { get; private set; }
        public double SamplingRate { get; private set; }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            SamplesNumber = Convert.ToInt32(SamplesBox.Text);
            SamplingRate = Convert.ToDouble(SamplingBox.Text, CultureInfo.InvariantCulture);

            DialogResult = true;
            Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}