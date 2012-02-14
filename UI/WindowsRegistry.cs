using System.Collections.Generic;
using System.Windows;
using UI.Models;

namespace UI
{
    public class WindowsRegistry : IFindWindows
    {
        IList<Window> _windows;
        IFindModels _modelRegistry;

        public WindowsRegistry() : this(new ModelRegistry())
        {
            
        }

        public WindowsRegistry(IFindModels modelRegistry)
        {
            _modelRegistry = modelRegistry;
            _windows = new List<Window>();
        }

        public void Register(Window window)
        {
            window.Closed += (s, e) => _windows.Remove(window);
            window.Closed += (s, e) => _modelRegistry.UnRegister(window.DataContext);

            _windows.Add(window);
        }

        public IEnumerable<Window> GetAll()
        {
            return _windows;
        }
    }
}