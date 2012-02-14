using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkPlus.CommonDomain.Extensions;
using UI.Events;
using UI.Models;

namespace UI
{
    public class StubFundDataRepository : IGetFundData
    {
        static IList<Func<FundDataModel>> _fundDataModelCreators;

        static StubFundDataRepository()
        {
            _fundDataModelCreators = new List<Func<FundDataModel>>
                                     {
                                         () => new FundDataModel{ RiskProfile = new RiskProfileModel { Name = "Combined" } },
                                         () => new FundDataModel{ RiskProfile = new RiskProfileModel { Name = "Long" } }
                                     };

        }

        public IList<FundDataModel> GetAll()
        {
            return _fundDataModelCreators.Select(x => x()).ToList();
        }

        public MainWindowModel GetFund()
        {
            return new MainWindowModel
            {
                DataTabs = _fundDataModelCreators.Select(x => x()).ToObservableCollection()
            };
        }

        public void Add(string riskProfileName)
        {
            _fundDataModelCreators.Add(() => new FundDataModel { RiskProfile = new RiskProfileModel { Name = riskProfileName } });
            UIEvents.Raise(new RiskProfileAddedEvent());
        }
    }
}