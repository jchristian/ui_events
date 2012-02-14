using UI.Events;

namespace UI.EventHandlers
{
    public class ValidateAddNewRiskProfileModel : IHandle<RiskProfileNameTextChangedEvent>
    {
        public void Handle(RiskProfileNameTextChangedEvent @event)
        {
            @event.Model.IsValid = !string.IsNullOrWhiteSpace(@event.Model.RiskProfileName);
        }
    }
}