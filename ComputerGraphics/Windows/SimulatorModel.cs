using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ComputerGraphics.Controls.ModelsUI;

namespace ComputerGraphics.Windows
{
    public sealed class SimulatorModel : INotifyPropertyChanged
    {
        public enum Simulations
        {
            [Description("Ноль")] Zero = 0,
            [Description("Один")] One = 1,
        }

        private object _view;

        public object View
        {
            get => _view;
            set
            {
                _view = value;
                OnPropertyChanged(nameof(View));
            }
        }

        public SimulatorModel()
        {
            View = new DelayedJump();
        }

        public void ChangeView(Simulations model)
        {
            View = model switch
            {
                Simulations.Zero => new DelayedJump(),
                Simulations.One => new DelayedPulse(),
                _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}