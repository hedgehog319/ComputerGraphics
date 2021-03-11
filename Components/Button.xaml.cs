using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace ComputerGraphics.Components
{
    /// <summary>
    /// Логика взаимодействия для Button.xaml
    /// </summary>
    public partial class Button : UserControl
    {
        public Button()
        {
            InitializeComponent();
        }

        public Brush BackGround
        {
            get => (Brush)GetValue(BackGroundProperty);
            set => SetValue(BackGroundProperty, value);
        }
        public static readonly DependencyProperty BackGroundProperty =
            DependencyProperty.Register("BackGround", typeof(Brush), typeof(Button), new PropertyMetadata(null));

        public Brush HoverBackGround { get; set; } = null;


        public string Text
        {
            get => TextB.Text;
            set => TextB.Text = value;
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (HoverBackGround == null) return;

            this.Grid.Background = HoverBackGround;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Grid.Background == Background) return;

            this.Grid.Background = Background;
        }
    }
}
