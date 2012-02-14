using System.Windows;
using UI.Events;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UIEvents.Raise(new ApplicationStartedEvent());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            UIEvents.Raise(new ApplicationClosedEvent());
        }
    }
}
