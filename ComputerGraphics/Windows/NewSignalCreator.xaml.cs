using System;
using System.Windows;

namespace ComputerGraphics.Windows
{
    public partial class NewSignalCreator : Window
    {
        public int SamplesNumber { get; private set; }
        public int SamplingRate { get; private set; }

        public NewSignalCreator()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            SamplesNumber = Convert.ToInt32(SamplesBox.Text);
            SamplingRate = Convert.ToInt32(SamplingBox.Text);

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}