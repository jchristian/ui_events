using UI.Events;
using UI.Models;

namespace UI.EventHandlers
{
    public class OpenAddNewRiskProfileWindow : IHandle<AddNewRiskProfileButtonClickedEvent>
    {
        ICreateWindows _windowFactory;
        IFindModels _findModels;

        public OpenAddNewRiskProfileWindow() : this(new WindowFactory(), new ModelRegistry()) { }

        public OpenAddNewRiskProfileWindow(ICreateWindows windowFactory, IFindModels findModels)
        {
            _windowFactory = windowFactory;
            _findModels = findModels;
        }

        public void Handle(AddNewRiskProfileButtonClickedEvent @event)
        {
            var window = _windowFactory.Create<AddNewRiskProfile>();
            window.Owner = @event.Parent;
            var model = new AddNewRiskProfileModel();
            window.DataContext = model;
            _findModels.Register(model);
            window.ShowDialog();
        }
    }
}