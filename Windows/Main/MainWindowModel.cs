#region

using System.ComponentModel;

#endregion

namespace ComputerGraphics.Windows.Main
{
    public sealed class MainWindowModel : INotifyPropertyChanged
    {
        private bool _isFileOpen;
        private bool _isNavBarOpen;

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

        public bool IsNavBarMayOpen => !IsNavBarOpen && IsFileOpen;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}