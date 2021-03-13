using ComputerGraphics.Utils;
using System.Windows;

namespace ComputerGraphics.Windows
{
    public partial class testWindow : Window
    {
        public testWindow()
        {
            InitializeComponent();
        }

        public testWindow(Channel<double> ch) : this()
        {
        }
    }
}