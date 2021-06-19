#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

#endregion

namespace ComputerGraphics.Controls
{
    public partial class UpBar : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(UpBar),
            new PropertyMetadata(string.Empty));

        private Window _parent;

        public UpBar()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private void UpBar_OnLoaded(object sender, RoutedEventArgs e)
        {
            var titleBind = new Binding
            {
                Path = new PropertyPath(nameof(Title)),
                Source = this
            };

            var backgroundBind = new Binding
            {
                Path = new PropertyPath(nameof(Background)),
                Source = this
            };

            TitleBox.SetBinding(TextBlock.TextProperty, titleBind);
            Grid.SetBinding(Panel.BackgroundProperty, backgroundBind);

            _parent = Window.GetWindow(this);
            if (_parent == null)
                throw new Exception("The parent of the UpBar is null");
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            _parent.Close();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                _parent.DragMove();
        }
    }
}