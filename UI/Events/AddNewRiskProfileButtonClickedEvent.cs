using System.Windows;

namespace UI.Events
{
    public class AddNewRiskProfileButtonClickedEvent
    {
        public virtual Window Parent { get; protected set; }

        public AddNewRiskProfileButtonClickedEvent(Window parent)
        {
            Parent = parent;
        }
    }
}