using BenchmarkPlus.CommonDomain.WPF.Models;
using UI.Events;

namespace UI.Models
{
    public class AddNewRiskProfileModel : NotifyPropertyChangedBase
    {
        string _riskProfileName;
        public string RiskProfileName
        {
            get { return _riskProfileName; }
            set
            {
                if (_riskProfileName == value)
                    return;
                _riskProfileName = value;
                RaisePropertyChanged(() => RiskProfileName);
            }
        }

        bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                if (_isValid == value)
                    return;
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public AddNewRiskProfileModel()
        {
            UIEvents.Raise(new RiskProfileNameTextChangedEvent(this));
        }
    }
}