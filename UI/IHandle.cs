namespace UI
{
    public interface IHandle<EventType>
    {
        void Handle(EventType @event);
    }
}