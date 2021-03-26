using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ComputerGraphics.Windows.Main
{
    public sealed class MainWindowModel : INotifyPropertyChanged
    {
        public MainWindowModel()
        {
        }

        private bool _isFileOpen = false;
        private bool _isNavBarOpen = false;

        public bool IsFileOpen
        {
            get => _isFileOpen;
            set
            {
                _isFileOpen = value;
                OnPropertyChanged(nameof(IsFileOpen));
            }
        }

        public bool IsNavBarOpen
        {
            get => _isNavBarOpen;
            set
            {
                _isNavBarOpen = value;
                OnPropertyChanged(nameof(IsNavBarOpen));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}