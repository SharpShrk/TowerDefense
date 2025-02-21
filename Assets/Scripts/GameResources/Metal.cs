using ObjectPools;
using Wallets;

namespace GameResources
{
    public class Metal : Resource
    {
        private int _value = 50;
        private ResourceWallet _metallWallet;
        private ResourcePool _pool;

        public void Initialize(ResourceWallet metalWallet, ResourcePool pool)
        {
            _metallWallet = metalWallet;
            _pool = pool;
        }

        protected override void AddValueInWallet()
        {
            _metallWallet.AddResource(_value);
        }

        protected override void ReturnToPool()
        {
            _pool.ReturnResource(this);
        }
    }
}