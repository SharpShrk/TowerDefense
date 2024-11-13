using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalWalletUI : RewardUI
{
    [SerializeField] private MetalWallet _metalWallet;

    protected override void OnEnable()
    {
        _metalWallet.MetalValueChanged += SetValue;
    }

    protected override void OnDisable()
    {
        _metalWallet.MetalValueChanged -= SetValue;
    }
}
