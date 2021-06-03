using System.Windows;

namespace ComputerGraphics.Windows
{
    public partial class Statistics : Window
    {
        public Statistics()
        {
            InitializeComponent();
            foreach (var model in WindowController.ChartModels)
            {
                box.Items.Add(model.ChannelName);
            }
        }
    }
}