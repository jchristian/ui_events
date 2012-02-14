using System.Collections.ObjectModel;
using BenchmarkPlus.CommonDomain.WPF.Models;

namespace UI.Models
{
    public class FundDataModel : NotifyPropertyChangedBase
    {
        ObservableCollection<MonthlyFundDataModel> _monthlyData;
        public ObservableCollection<MonthlyFundDataModel> MonthlyData
        {
            get { return _monthlyData; }
            set
            {
                if (_monthlyData == value)
                    return;
                _monthlyData = value;
                RaisePropertyChanged(() => MonthlyData);
            }
        }


        RiskProfileModel _riskProfile;
        public RiskProfileModel RiskProfile
        {
            get { return _riskProfile; }
            set
            {
                if (_riskProfile == value)
                    return;
                _riskProfile = value;
                RaisePropertyChanged(() => RiskProfile);
            }
        }
    }
}