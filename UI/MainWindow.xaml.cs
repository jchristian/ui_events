using System.Windows;
using UI.Events;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void OnAddClick(object sender, RoutedEventArgs e)
        {
            UIEvents.Raise(new AddNewRiskProfileButtonClickedEvent(this));
        }
    }
}
