using LocationFromGoogle.Core;
using LocationFromGoogle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LocationFromGoogle.MVVM.View;
using System.IO;
using System.Windows;
using System.Threading;

namespace LocationFromGoogle.MVVM.ViewModel
{
    class DataGridViewModel : ObservableObject
    {
        private static readonly string myDocumentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string dataFolderPath = Path.Combine(myDocumentsFolderPath, "My Google Location History"); // Pfad zum Programmordner

        private IEnumerable<TimelineObject> _TLO_List; // DataList the DataGrid is working with
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
            if (!Directory.Exists(dataFolderPath))
                Directory.CreateDirectory(dataFolderPath); // Falls er nicht existiert, erstellen

            LoadSampleData();
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
        private IEnumerable<TimelineObject> _JsonData; // All Data from JSON Files
        public RelayCommand BTN_LoadData => new RelayCommand(PerformLoad);
        private void PerformLoad(object commandParameter)
        {
            ButtonLoadText = "Loading...";
            Spinner = "Visible";            

            _JsonData = DeSerializer.Process(dataFolderPath);

            var query = _JsonData.Where(x => x.PlaceVisit != null
                                          && x.ActivitySegment != null)
                                 .Select(x => x)
                                 .OrderBy(x => x.ActivitySegment.Duration.StartTimestampDT.Date);

            TLO_List = query.ToList();

            ButtonLoadText = "Reload";
            Spinner = "Collapsed";
        }

        public RelayCommand BTN_SelectDate => new RelayCommand(PerformSelect);
        private void PerformSelect(object commandParameter)
        {
            if (_JsonData == null)
            {
                MessageBox.Show("Please Load Data first.", "No Data found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var query = _JsonData.Where((x) => x.PlaceVisit != null
                                               && x.ActivitySegment != null
                                               && x.PlaceVisit.Duration.StartTimestampDT > SelectedDateFrom
                                               && x.PlaceVisit.Duration.StartTimestampDT < SelectedDateUntil)
                                    .Select((x) => x);
                TLO_List = query.ToList();
            }
        }

        public RelayCommand BTN_Reset => new RelayCommand(PerformReset);
        private void PerformReset(object commandParameter)
        {
            if (_JsonData == null)
            {
                MessageBox.Show("Please Load Data first.", "No Data found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var query = _JsonData.Where((x) => x.PlaceVisit != null
                                           && x.ActivitySegment != null)
                                .Select((x) => x);

                TLO_List = query.ToList();
            }
        }

        private string _buttonLoadText = "Load";
        public string ButtonLoadText
        {
            get { return _buttonLoadText; }
            set
            {
                _buttonLoadText = value;
                OnPropertyChanged();
            }
        }
        private string _spinner = "Collapsed";
        public string Spinner
        {
            get { return _spinner; }
            set
            {
                _spinner = value;
                OnPropertyChanged();
            }
        }
        private void LoadSampleData()
        {
            _JsonData = DeSerializer.Process(@".\SampleData\");

            var query = _JsonData.Where(x => x.PlaceVisit != null
                                          && x.ActivitySegment != null)
                                 .Select(x => x)
                                 .OrderBy(x => x.ActivitySegment.Duration.StartTimestampDT.Date);

            TLO_List = query.ToList();
        }
    }
}