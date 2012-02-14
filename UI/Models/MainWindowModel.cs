using System.Collections.ObjectModel;
using BenchmarkPlus.CommonDomain.WPF.Models;

namespace UI.Models
{
    public class MainWindowModel : NotifyPropertyChangedBase
    {
        ObservableCollection<FundDataModel> _dataTabs;
        public ObservableCollection<FundDataModel> DataTabs
        {
            get { return _dataTabs; }
            set
            {
                if (_dataTabs == value)
                    return;
                _dataTabs = value;
                RaisePropertyChanged(() => DataTabs);
            }
        }
    }
}