#region

using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using LiveCharts.Wpf;

#endregion

namespace ComputerGraphics.Charts
{
    public class OscillogramModel : BaseModel
    {
        private double _max;
        private double _min;
        private bool _point;
        private double _smoothness;

        public OscillogramModel()
        {
        }

        public OscillogramModel(string name, string source, IReadOnlyCollection<double> values) : base(name, source,
            values)
        {
            Min = values.Min();
            Max = values.Max();

            Smoothness = 1;
        }

        public double Max
        {
            get => _max;
            set
            {
                if (Equals(_max, value)) return;

                _max = value;
                OnPropertyChanged(nameof(Max));
            }
        }

        public double Min
        {
            get => _min;
            set
            {
                if (Equals(_min, value)) return;

                _min = value;
                OnPropertyChanged(nameof(_min));
            }
        }

        public double Smoothness
        {
            get => _smoothness;
            set
            {
                if (Equals(_smoothness, value)) return;

                _smoothness = value;
                OnPropertyChanged(nameof(Smoothness));
            }
        }

        // TODO don't work
        public Geometry GetPoint => _point ? DefaultGeometries.Circle : DefaultGeometries.None;

        public bool SetPoint
        {
            get => _point;
            set
            {
                if (Equals(_point, value)) return;

                _point = value;
                OnPropertyChanged(nameof(GetPoint));
                OnPropertyChanged(nameof(SetPoint));
            }
        }
    }
}