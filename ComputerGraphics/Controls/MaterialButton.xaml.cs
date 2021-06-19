#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#endregion

namespace ComputerGraphics.Controls
{
    public partial class MaterialButton : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(MaterialButton));

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register(
                "HoverBackground",
                typeof(Brush),
                typeof(MaterialButton));

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.Register(
                "HoverForeground",
                typeof(Brush),
                typeof(MaterialButton));

        public static readonly DependencyProperty BackGroundProperty =
            DependencyProperty.Register(
                "BackGround",
                typeof(Brush),
                typeof(MaterialButton));

        public MaterialButton()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Brush HoverBackground
        {
            get => (Brush) GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        public Brush HoverForeground
        {
            get => (Brush) GetValue(HoverForegroundProperty);
            set => SetValue(HoverForegroundProperty, value);
        }

        public Brush BackGround
        {
            get => (Brush) GetValue(BackGroundProperty);
            set => SetValue(BackGroundProperty, value);
        }

        private void MaterialButton_OnLoaded(object sender, RoutedEventArgs e)
        {
        }
    }
}