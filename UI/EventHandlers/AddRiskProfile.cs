using UI.Events;

namespace UI.EventHandlers
{
    public class AddRiskProfile : IHandle<AddNewRiskProfileEvent>
    {
        IGetFundData _fundDataRepository;

        public AddRiskProfile() : this(new StubFundDataRepository()) { }

        public AddRiskProfile(IGetFundData fundDataRepository)
        {
            _fundDataRepository = fundDataRepository;
        }

        public void Handle(AddNewRiskProfileEvent @event)
        {
            _fundDataRepository.Add(@event.RiskProfileName);
        }
    }
}