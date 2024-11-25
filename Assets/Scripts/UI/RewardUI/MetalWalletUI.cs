using UnityEngine;
using Wallets;

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
