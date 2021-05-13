using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ComputerGraphics.Charts;
using ComputerGraphics.Controls.ModelsUI;

namespace ComputerGraphics.Windows
{
    public partial class Simulator : Window
    {
        private readonly SimulatorModel _model;

        public Simulator()
        {
            InitializeComponent();
            _model = DataContext as SimulatorModel;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Selector_OnSelected(object sender, RoutedEventArgs e)
        {
            if (sender is not ComboBox comboBox) return;

            _model.ChangeView((SimulatorModel.Simulations) comboBox.SelectedIndex);
            var view = _model.View as ISimulated;
            var simulation = view?.Simulation();

            //TODO change name and source
            var oscillogramModel = new OscillogramModel("name", "Sim_Name", simulation);
            WindowController.ChartModels.OscillogramModels.Add(oscillogramModel);

            WindowController.AddOscillogram(oscillogramModel.Id);
            Close();
        }
    }
}