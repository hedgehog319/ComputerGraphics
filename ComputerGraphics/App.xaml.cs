#region

using System.Windows;
using ComputerGraphics.Windows;

#endregion

namespace ComputerGraphics
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            WindowController.ShowMainWindow();
        }
    }
}