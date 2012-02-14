using BenchmarkPlus.CommonDomain.WPF.Models;

namespace UI.Models
{
    public class RiskProfileModel : NotifyPropertyChangedBase
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name)
                    return;

                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }
    }
}