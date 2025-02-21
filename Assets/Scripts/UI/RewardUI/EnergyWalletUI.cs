using UnityEngine;
using Wallets;

namespace UI.RewardUI
{
    public class EnergyWalletUI : RewardUI
    {
        [SerializeField] private ResourceWallet _energyWallet;

        protected override void OnEnable()
        {
            _energyWallet.ValueChanged += SetValue;
        }

        protected override void OnDisable()
        {
            _energyWallet.ValueChanged -= SetValue;
        }
    }
}