#region

using System.Collections.Generic;

#endregion

namespace ComputerGraphics.Controls.ModelsUI
{
    public interface ISimulated
    {
        public List<double> Simulation();
    }
}