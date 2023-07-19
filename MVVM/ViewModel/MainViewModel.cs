using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Triangles.Base;

namespace Triangles.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand InfoViewCommand { get; set; }
        public InfoViewModel InfoVM { get; set; }

        private string _text1;
        private string _text2;
        private string _text3;

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }


        public string Text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                OnPropertyChanged("Text1");
            }
        }

        public string Text2
        {
            get { return _text2; }
            set
            {
                _text2 = value;
                OnPropertyChanged("Text2");
            }
        }

        public string Text3
        {
            get { return _text3; }
            set
            {
                _text3 = value;
                OnPropertyChanged("Text3");
            }
        }

        private void Clear()
        {
            Text1 = string.Empty;
            Text2 = string.Empty;
            Text3 = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            InfoVM = new InfoViewModel();
            CurrentView = InfoVM;

            InfoViewCommand = new RelayCommand(o =>
            {
                CurrentView = InfoVM;
            });

            
        }

    }
}
