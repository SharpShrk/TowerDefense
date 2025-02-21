using ObjectPools;
using Wallets;

namespace GameResources
{
    public class Energy : Resource
    {
        private int _value = 25;
        private ResourceWallet _energyWallet;
        private ResourcePool _pool;

        public void Initialize(ResourceWallet energyWallet, ResourcePool pool)
        {
            _energyWallet = energyWallet;
            _pool = pool;
        }

        protected override void AddValueInWallet()
        {
            _energyWallet.AddResource(_value);
            ReturnToPool();
        }

        protected override void ReturnToPool()
        {
            _pool.ReturnResource(this);
        }
    }
}