using System.Collections.Generic;
using UI.Models;

namespace UI
{
    public interface IGetFundData
    {
        IList<FundDataModel> GetAll();
        MainWindowModel GetFund();

        void Add(string riskProfileName);
    }
}