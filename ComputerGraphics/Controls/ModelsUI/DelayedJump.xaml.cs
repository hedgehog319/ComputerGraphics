using System.Collections.Generic;
using System.Windows.Controls;

namespace ComputerGraphics.Controls.ModelsUI
{
    public partial class DelayedJump : UserControl, ISimulated
    {
        public DelayedJump()
        {
            InitializeComponent();
        }

        public List<double> Simulation()
        {
            throw new System.NotImplementedException();
        }
    }
}