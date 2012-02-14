namespace UI.Events
{
    public class AddNewRiskProfileEvent 
    {
        public string RiskProfileName { get; private set; }

        public AddNewRiskProfileEvent(string riskProfileName)
        {
            RiskProfileName = riskProfileName;
        }
    }
}