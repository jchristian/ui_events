using System.Diagnostics;
using BenchmarkPlus.CommonDomain.Extensions;
using UI.Events;

namespace UI.EventHandlers
{
    public class CloseAllWindows : IHandle<ApplicationClosedEvent>
    {
        IFindWindows _windowsRegistry;

        public CloseAllWindows() : this(new WindowsRegistry()){}

        public CloseAllWindows(IFindWindows windowsRegistry)
        {
            _windowsRegistry = windowsRegistry;
        }

        public void Handle(ApplicationClosedEvent @event)
        {
            _windowsRegistry.GetAll().Each(x => { x.Close();
                                                    Debug.WriteLine("We just closed joo <{0}>", x.ToString());
            });
        }
    }
}