using UnityEngine;
using Wallets;

namespace UI.RewardUI
{
    public class MetalWalletUI : RewardUI
    {
        [SerializeField] private MetalWallet _metalWallet;

        protected override void OnEnable()
        {
            _metalWallet.ValueChanged += SetValue;
        }

        protected override void OnDisable()
        {
            _metalWallet.ValueChanged -= SetValue;
        }
    }
}