using System.Windows.Controls;

namespace ComputerGraphics.Charts
{
    public partial class ColumnChart : UserControl
    {
        public ColumnChart(OscillogramModel model)
        {
            InitializeComponent();

            DataContext = model;
        }

        public OscillogramModel GetModel => DataContext as OscillogramModel;

        public void Dispose() => GetModel?.Values.Dispose();
    }
}