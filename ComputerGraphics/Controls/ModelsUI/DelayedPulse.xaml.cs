using System.Collections.Generic;
using System.Windows.Controls;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DelayedPulse : UserControl, ISimulated
    {
        public DelayedPulse()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            throw new System.NotImplementedException();
        }
    }
}