using BenchmarkPlus.CommonDomain.Extensions;

namespace UI
{
    public class UIEvents
    {
        public static EventHandlerRegistry _eventRouter = new EventHandlerRegistry();

        public static void Raise<EventType>(EventType @event)
        {
            _eventRouter.Find(@event).Each(x => x.Handle(@event));
        }
    }
}