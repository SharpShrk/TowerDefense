namespace ResourcesFactories
{
    public class EnergyFactory : ResourcesFactory
    {
        private void OnEnable()
        {
            Type = BuildType.EnergyFactory;
        }
    }
}