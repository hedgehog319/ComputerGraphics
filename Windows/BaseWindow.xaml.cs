using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace ComputerGraphics.Windows
{
    public partial class BaseWindow : UserControl
    {
        private bool _isMove = false;

        private Point _click = new Point(0, 0);
        private readonly TranslateTransform _transform = new TranslateTransform();

        public BaseWindow()
        {
            InitializeComponent();

            this.RenderTransform = _transform;
        }

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
    }
}