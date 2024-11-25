using UnityEngine;
using Wallets;

public class EnergyWalletUI : RewardUI
{
    [SerializeField] private EnergyWallet _energyWallet;

    protected override void OnEnable()
    {
        _energyWallet.ValueChanged += SetValue;
    }

    protected override void OnDisable()
    {
        _energyWallet.ValueChanged -= SetValue;
    }
}
