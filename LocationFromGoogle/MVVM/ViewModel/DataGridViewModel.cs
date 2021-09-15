using LocationFromGoogle.Core;
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
                OnPropertyChanged();
                _TLO_List = value;
            }
        }
        public DataGridViewModel()
        {
            var JsonData = DeSerializer.GetDataListFromJsonFile();
            TLO_List = JsonData;
        }
    }
}