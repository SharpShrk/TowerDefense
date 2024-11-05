namespace GameResources
{
    public class Metal : Resource
    {
        private int _value = 50;
        private MetalWallet _wallet;
        private ResourcePool _pool;

        public void Initialize(MetalWallet metalWallet, ResourcePool pool)
        {
            _wallet = metalWallet;
            _pool = pool;
        }

        protected override void AddValueInWallet()
        {
            _wallet.AddMetal(_value);
        }

        protected override void ReturnToPool()
        {
            _pool.ReturnResource(this);
        }
    }
}