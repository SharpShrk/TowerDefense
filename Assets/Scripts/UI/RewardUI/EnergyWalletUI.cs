using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWalletUI : RewardUI
{
    [SerializeField] private EnergyWallet _energyWallet;

    protected override void OnEnable()
    {
        _energyWallet.EnergyValueChanged += SetValue;
    }

    protected override void OnDisable()
    {
        _energyWallet.EnergyValueChanged -= SetValue;
    }
}
