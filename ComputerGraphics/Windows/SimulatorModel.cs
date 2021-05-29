#region

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ComputerGraphics.Controls.ModelsUI;

#endregion

namespace ComputerGraphics.Windows
{
    public sealed class SimulatorModel : INotifyPropertyChanged
    {
        public enum Simulations
        {
            [Description("Задержанный единичный импульс")]
            Zero = 0,

            [Description("Задержанный единичный скачок ")]
            One = 1,

            [Description("Дискретизированная убывающая экспонента")]
            Two = 2,
            [Description("Синусоида")] Tree = 3,
            [Description("Меандр")] Four = 4,
            [Description("Пила")] Five = 5,

            [Description("Экпоненциальная огибающая")]
            Six = 6,

            [Description("Балансирующая огибающая")]
            Seven = 7,
            [Description("Тональная Огибающая")] Eight = 8,

            [Description("Сигнал с линейной частотной модуляцией ")]
            Nine = 9,
            [Description("Белый Шум")] Ten = 10,

            [Description("Белый Шум по нормальному закону")]
            Eleven = 11,
            [Description("АРСС")] Twelve = 12
        }

        private object _view;

        public SimulatorModel()
        {
            View = null;
        }

        public object View
        {
            get => _view;
            set
            {
                _view = value;
                OnPropertyChanged(nameof(View));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeView(Simulations model)
        {
            UserControl control = model switch
            {
                Simulations.Zero => new DelayedJump(),
                Simulations.One => new DelayedPulse(),
                Simulations.Two => new DiscretizedDecreasingExponent(),
                Simulations.Tree => new Sinusoid(),
                Simulations.Four => new Meandr(),
                Simulations.Five => new Pila(),
                Simulations.Six => new ExponentialEnvelope(),
                Simulations.Seven => new BalancedEnvelope(),
                Simulations.Eight => new TonalEnvelope(),
                Simulations.Nine => new LChM(),
                Simulations.Ten => new WhiteNoise(),
                Simulations.Eleven => new NormalWhiteNoise(),
                Simulations.Twelve => new APCC(),
                _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
            };

            Height = control.Height;
            Width = control.Width;

            View = control;
        }

        private double _width = 210;

        public double Width
        {
            get => _width;
            private set
            {
                if (!Equals(_width, value)) _width = value;
            }
        }

        private double _height = 95;

        public double Height
        {
            get => _height;
            private set
            {
                if (!Equals(_height, 95 + value)) _height = 95 + value;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}