using System;
using LocationFromGoogle.Core;

namespace LocationFromGoogle.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DataGridViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DataGridViewModel DataGridVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new();
            DataGridVM = new();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            DataGridViewCommand = new RelayCommand(o =>
            {
                CurrentView = DataGridVM;
            });
        }
    }
}
