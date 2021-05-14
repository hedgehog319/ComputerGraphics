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
            [Description("Задержанный единичный импульс")] Zero = 0,
            [Description("Задержанный единичный скачок ")] One = 1,
            [Description("Дискретизированная убывающая экспонента")] Two = 2,
            [Description("Синусоида")] Tree = 3,
            [Description("Меандр")] Four = 4,
            [Description("Пила")] Five = 5,
            [Description("Пила")] Six = 6,
            [Description("Пила")] Seven = 7,
            [Description("Пила")] Eight  = 8,
            [Description("Пила")] Nine = 9,
            
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
                Simulations.Two => new DiscretizedDecreasingExponent(),
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