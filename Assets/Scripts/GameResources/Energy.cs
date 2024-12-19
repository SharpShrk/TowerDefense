using Wallets;

namespace GameResources
{
    public class Energy : Resource
    {
        private int _value = 25;
        private EnergyWallet _wallet;
        private ResourcePool _pool;

        public void Initialize(EnergyWallet energyWallet, ResourcePool pool)
        {
            _wallet = energyWallet;
            _pool = pool;
        }

        protected override void AddValueInWallet()
        {
            _wallet.AddResource(_value);
            ReturnToPool();
        }

        protected override void ReturnToPool()
        {
            _pool.ReturnResource(this);
        }
    }
}