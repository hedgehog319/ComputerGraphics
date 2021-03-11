using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Windows.Point;

namespace ComputerGraphics.Windows
{
    public partial class BaseWindow : UserControl
    {
        private bool _isMove = false;

        private Point _click = new(0, 0);
        private TranslateTransform _transform;

        public BaseWindow()
        {
            InitializeComponent();

            _transform = new();
            this.RenderTransform = _transform;
        }

        public void SetTranslate(TranslateTransform translate) => _transform = translate;

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _isMove = true;
            _click = e.GetPosition(this);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e) => _isMove = false;

        private void OnMouseLeave(object sender, MouseEventArgs e) => _isMove = false;

        private void Translate(Point p)
        {
            var delta = _click - p;

            _transform.X -= delta.X;
            _transform.Y -= delta.Y;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMove) return;

            Translate(e.GetPosition(this));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Rectangle rect) return;
        }
    }
}