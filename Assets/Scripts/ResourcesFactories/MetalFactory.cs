namespace ResourcesFactories
{
    public class MetalFactory : ResourcesFactory
    {
        private void OnEnable()
        {
            Type = BuildType.MetalFactory;
        }
    }
}