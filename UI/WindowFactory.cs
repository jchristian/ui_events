using System.Windows;
using UI.EventHandlers;
using UI.Events;

namespace UI
{
    public class WindowFactory : ICreateWindows
    {
        IFindWindows _windowsRegistry;

        public WindowFactory()
        {
            _windowsRegistry = new WindowsRegistry();
        }

        public WindowType Create<WindowType>() where WindowType : Window, new()
        {
            var theWindow = new WindowType();
            _windowsRegistry.Register(theWindow);
            return theWindow;
        }
    }
}