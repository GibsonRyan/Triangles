using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Triangles.Base;
using Triangles.Helpers;

namespace Triangles.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand InfoViewCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public InfoViewModel InfoVM { get; set; }
        public InputViewModel InputVM { get; set; }


        private string _side1;
        private string _side2;
        private string _side3;

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


        public string Side1
        {
            get { return _side1; }
            set
            {
                _side1 = value;
                OnPropertyChanged(nameof(Side1));
                CalculateTriangleProperties();
            }
        }

        public string Side2
        {
            get { return _side2; }
            set
            {
                _side2 = value;
                OnPropertyChanged(nameof(Side2));
                CalculateTriangleProperties();
            }
        }

        public string Side3
        {
            get { return _side3; }
            set
            {
                _side3 = value;
                OnPropertyChanged(nameof(Side3));
                CalculateTriangleProperties();
            }
        }

        public MainViewModel()
        {
            InfoVM = new InfoViewModel();
            InputVM = new InputViewModel();
            CurrentView = InputVM;

            ClearCommand = new RelayCommand(o => Clear());
        }

        private void Clear()
        {
            Side1 = string.Empty;
            Side2 = string.Empty;
            Side3 = string.Empty;
        }

        private void CalculateTriangleProperties()
        {
            if (double.TryParse(Side1, out double s1) &&
                double.TryParse(Side2, out double s2) &&
                double.TryParse(Side3, out double s3))
            {
                CurrentView = InfoVM;
                if (s1 + s2 > s3 && s1 + s3 > s2 && s2 + s3 > s1)
                {
                    List<double> angles = TriangleCalculator.CalculateAngleValues(s1, s2, s3);
                    for (int i = 0; i < angles.Count; i++)
                    {
                        angles[i] = Math.Round(angles[i], 2);
                    }

                    InfoVM.IsValidTriangle = "The side lengths \nprovided make a \nvalid triangle";
                    InfoVM.SideClassification = TriangleCalculator.CalculateSideClassification(s1, s2, s3);
                    InfoVM.AngleClassification = TriangleCalculator.CalculateAngleClassification(s1, s2, s3);
                    InfoVM.AngleValues = $"Angle 1: {angles[0]}° \nAngle 2: {angles[1]}° \nAngle 3: {angles[2]}°";
                }
                else
                {
                    InfoVM.IsValidTriangle = "The side lengths \nprovided do not \nform a valid \ntriangle";
                    InfoVM.SideClassification = "N/A";
                    InfoVM.AngleClassification = "N/A";
                    InfoVM.AngleValues = "Angle 1: N/A \nAngle 2: N/A \nAngle 3: N/A";
                }
            }
            else
            {
                CurrentView = InputVM;
            }
        }

    }
}
