using System.Windows;
using System.Windows.Controls;
using UI.Events;
using UI.Models;

namespace UI
{
    /// <summary>
    /// Interaction logic for AddNewRiskProfile.xaml
    /// </summary>
    public partial class AddNewRiskProfile : Window
    {
        public AddNewRiskProfile()
        {
            InitializeComponent();
        }

        void OnAddRiskProfileClick(object sender, RoutedEventArgs e)
        {
            UIEvents.Raise(new AddNewRiskProfileEvent(txtRiskProfileName.Text));
        }

        void RiskProfileNameTextChanged(object sender, TextChangedEventArgs e)
        {
            UIEvents.Raise(new RiskProfileNameTextChangedEvent((AddNewRiskProfileModel)DataContext));
        }
    }
}
