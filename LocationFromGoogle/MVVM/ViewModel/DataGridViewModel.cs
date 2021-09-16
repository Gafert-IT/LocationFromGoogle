﻿using LocationFromGoogle.Core;
using LocationFromGoogle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LocationFromGoogle.MVVM.View;

namespace LocationFromGoogle.MVVM.ViewModel
{
    class DataGridViewModel : ObservableObject
    {
        private IEnumerable<TimelineObject> _TLO_List;
        private IEnumerable<TimelineObject> JsonData;
        private static readonly string selection = @"D:\Visual Studio Projekte\LocationFromGoogle\LocationFromGoogle\LocationHistory\";

        public IEnumerable<TimelineObject> TLO_List
        {
            get { return _TLO_List; }
            set
            {
                _TLO_List = value;
                OnPropertyChanged();
            }
        }
        public DataGridViewModel()
        {
            JsonData = DeSerializer.Process(selection);

            var query = JsonData.Where((x) => x.PlaceVisit != null
                                           && x.ActivitySegment != null)
                                .Select((x) => x);

            TLO_List = query.ToList();
        }

        // DatePicker
        private DateTime _selectedDateFrom = new DateTime(2016, 08, 01);
        public DateTime SelectedDateFrom
        {
            get { return _selectedDateFrom; }
            set
            {
                _selectedDateFrom = value;
                OnPropertyChanged();
            }
        } 
        private DateTime _selectedDateUntil = DateTime.Now;
        public DateTime SelectedDateUntil
        {
            get { return _selectedDateUntil; }
            set
            {
                _selectedDateUntil = value;
                OnPropertyChanged();
            }
        }

        // Button Commands
        public ICommand BTN_SelectDate => new RelayCommand(PerformSelect);
        private void PerformSelect(object commandParameter)
        {
            var query = JsonData.Where((x) => x.PlaceVisit != null
                                           && x.ActivitySegment != null
                                           && x.PlaceVisit.Duration.StartTimestampDT > SelectedDateFrom
                                           && x.PlaceVisit.Duration.StartTimestampDT < SelectedDateUntil)
                                .Select((x) => x);
            TLO_List = query.ToList();
        }

        public ICommand BTN_Reset => new RelayCommand(PerformReset);
        private void PerformReset(object commandParameter)
        {
            var query = JsonData.Where((x) => x.PlaceVisit != null
                                           && x.ActivitySegment != null)
                                .Select((x) => x);

            TLO_List = query.ToList();
        }
    }
}