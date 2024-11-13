using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWalletUI : RewardUI
{
    [SerializeField] private EnergyWallet _energyWallet;

    protected override void OnEnable()
    {
        _energyWallet.OnEnergyValueChanged += SetValue;
    }

    protected override void OnDisable()
    {
        _energyWallet.OnEnergyValueChanged -= SetValue;
    }
}