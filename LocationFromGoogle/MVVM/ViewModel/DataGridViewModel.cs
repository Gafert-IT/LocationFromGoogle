﻿using LocationFromGoogle.Core;
using LocationFromGoogle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationFromGoogle.MVVM.ViewModel
{
    class DataGridViewModel : ObservableObject
    {
        private IEnumerable<TimelineObject> _TLO_List;

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
            var query = DeSerializer.GetDataListFromJsonFile();
            TLO_List = query;
        }
    }
}