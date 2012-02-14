using UI.Models;

namespace UI.Events
{
    public class RiskProfileNameTextChangedEvent
    {
        public AddNewRiskProfileModel Model { get; private set; }

        public RiskProfileNameTextChangedEvent(AddNewRiskProfileModel model)
        {
            Model = model;
        }
    }
}