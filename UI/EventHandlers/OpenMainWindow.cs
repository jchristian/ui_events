using UI.Events;
using UI.Models;

namespace UI.EventHandlers
{
    public class OpenMainWindow : IHandle<ApplicationStartedEvent>
    {
        IGetFundData _fundDataRepository;
        ICreateWindows _windowFactory;
        IFindModels _modelRegistry;

        public OpenMainWindow() : this(new StubFundDataRepository(), new WindowFactory(), new ModelRegistry()) {}

        public OpenMainWindow(IGetFundData fundDataRepository, ICreateWindows windowFactory, IFindModels modelRegistry)
        {
            _fundDataRepository = fundDataRepository;
            _windowFactory = windowFactory;
            _modelRegistry = modelRegistry;
        }

        public void Handle(ApplicationStartedEvent @event)
        {
            OpenWindow();
            OpenWindow();
        }

        void OpenWindow()
        {
            var window = _windowFactory.Create<MainWindow>();

            var model = _fundDataRepository.GetFund();
            _modelRegistry.Register(model);
            window.DataContext = model;
            window.Show();
        }
    }
}