﻿using System;
using Triangles.Base;

namespace Triangles.MVVM.ViewModel
{
    class InfoViewModel : ObservableObject
    {
        private string _sideClassification;
        private string _angleClassification;
        private string _angleValues;
        private string _isValidTriangle;


        public string SideClassification
        {
            get { return _sideClassification; }
            set
            {
                _sideClassification = value;
                OnPropertyChanged(nameof(SideClassification));
            }
        }

        public string AngleClassification
        {
            get { return _angleClassification; }
            set
            {
                _angleClassification = value;
                OnPropertyChanged(nameof(AngleClassification));
            }
        }

        public string AngleValues
        {
            get { return _angleValues; }
            set
            {
                _angleValues = value;
                OnPropertyChanged(nameof(AngleValues));
            }
        }

        public string IsValidTriangle
        {
            get { return _isValidTriangle; }
            set
            {
                _isValidTriangle = value;
                OnPropertyChanged(nameof(IsValidTriangle));
            }
        }
    }


}
