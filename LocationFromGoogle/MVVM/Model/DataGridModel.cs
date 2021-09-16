using LocationFromGoogle.Core;
using LocationFromGoogle.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocationFromGoogle.MVVM.Model
{
    internal class DataGridModel
    {
        //// Button Commands
        //public ICommand BTN_SelectDate => new RelayCommand(PerformSelect);
        //private void PerformSelect(object commandParameter)
        //{
        //    var query = DataGridViewModel.JsonData.Where((x) => x.PlaceVisit != null
        //                                   && x.ActivitySegment != null
        //                                   && x.PlaceVisit.Duration.StartTimestampDT > SelectedDateFrom
        //                                   && x.PlaceVisit.Duration.StartTimestampDT < SelectedDateUntil)
        //                        .Select((x) => x);
        //    DataGridViewModel._TLO_List = query.ToList();
        //}

        //public ICommand BTN_Reset => new RelayCommand(PerformReset);
        //private void PerformReset(object commandParameter)
        //{
        //    var query = DataGridViewModel.JsonData.Where((x) => x.PlaceVisit != null
        //                                   && x.ActivitySegment != null)
        //                        .Select((x) => x);

        //    DataGridViewModel._TLO_List = query.ToList();
        //}
    }
}
