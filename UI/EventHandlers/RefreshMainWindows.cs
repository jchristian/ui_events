using BenchmarkPlus.CommonDomain.Extensions;
using UI.Events;
using UI.Models;

namespace UI.EventHandlers
{
    public class RefreshMainWindows : IHandle<RiskProfileAddedEvent>
    {
        IFindModels _viewRegistry;
        IGetFundData _fundDataRegistry;

        public RefreshMainWindows() : this(new ModelRegistry(), new StubFundDataRepository()) {}

        public RefreshMainWindows(IFindModels viewRegistry, IGetFundData fundDataRegistry)
        {
            _viewRegistry = viewRegistry;
            _fundDataRegistry = fundDataRegistry;
        }

        public void Handle(RiskProfileAddedEvent @event)
        {
            var dataTabs = _fundDataRegistry.GetAll();
            _viewRegistry.FindAll<MainWindowModel>().Each(x => x.DataTabs = dataTabs.ToObservableCollection());
        }
    }
}