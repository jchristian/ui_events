using System;
using System.Collections.Generic;
using System.Linq;
using UI.EventHandlers;
using UI.Events;

namespace UI
{
    public class EventHandlerRegistry
    {
        IDictionary<Type, IEnumerable<Func<object>>> _eventHandlers;

        public EventHandlerRegistry()
        {
            _eventHandlers = new Dictionary<Type, IEnumerable<Func<object>>>();

            _eventHandlers.Add(typeof(ApplicationStartedEvent), new Func<object>[] { () => new OpenMainWindow() });
            _eventHandlers.Add(typeof(ApplicationClosedEvent), new Func<object>[] { () => new CloseAllWindows() });
            _eventHandlers.Add(typeof(AddNewRiskProfileButtonClickedEvent), new Func<object>[] { () => new OpenAddNewRiskProfileWindow() });
            _eventHandlers.Add(typeof(AddNewRiskProfileEvent), new Func<object>[] { () => new AddRiskProfile() });
            _eventHandlers.Add(typeof(RiskProfileAddedEvent), new Func<object>[] { () => new RefreshMainWindows() });
            _eventHandlers.Add(typeof(RiskProfileNameTextChangedEvent), new Func<object>[] { () => new ValidateAddNewRiskProfileModel() });
        }

        public IEnumerable<IHandle<EventType>> Find<EventType>(EventType @event)
        {
            return _eventHandlers[typeof(EventType)].Select(x => (IHandle<EventType>)x()).ToList();
        }
    }
}