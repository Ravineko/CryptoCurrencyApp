using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Utilities;

namespace WpfApp1.ViewModels
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand HomeCommand { get; }
        public ICommand ChartsCommand { get; }
        public ICommand ConvertCommand { get; }

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            ChartsCommand = new RelayCommand(Charts);
            ConvertCommand = new RelayCommand(Convert);

            // Startup Page
            CurrentView = new HomeViewModel();
        }

        private void Home(object obj) => CurrentView = new HomeViewModel();

        private void Charts(object obj) => CurrentView = new ChartsViewModel();
        private void Convert(object obj) => CurrentView = new ConvertViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
