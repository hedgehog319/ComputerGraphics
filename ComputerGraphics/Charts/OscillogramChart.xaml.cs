#region

using System;

#endregion

namespace ComputerGraphics.Charts
{
    public partial class OscillogramChart : IDisposable
    {
        public OscillogramChart(OscillogramModel model)
        {
            InitializeComponent();

            DataContext = model;
        }

        public OscillogramModel GetModel => DataContext as OscillogramModel;

        public void Dispose() => GetModel?.Values.Dispose();
    }
}