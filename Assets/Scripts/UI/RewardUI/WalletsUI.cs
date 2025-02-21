using UnityEngine;
using Wallets;

namespace UI.RewardUI
{
    public class WalletsUI : RewardUI
    {
        [SerializeField] private ResourceWallet _wallet;

        protected override void OnEnable()
        {
            _wallet.ValueChanged += SetValue;
        }

        protected override void OnDisable()
        {
            _wallet.ValueChanged -= SetValue;
        }
    }
}