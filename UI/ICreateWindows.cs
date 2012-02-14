using System.Windows;

namespace UI
{
    public interface ICreateWindows
    {
        WindowType Create<WindowType>() where WindowType : Window, new();
    }
}