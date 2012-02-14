using System.Collections.Generic;
using System.Windows;

namespace UI
{
    public interface IFindWindows
    {
        IEnumerable<Window> GetAll();

        void Register(Window window);
    }
}