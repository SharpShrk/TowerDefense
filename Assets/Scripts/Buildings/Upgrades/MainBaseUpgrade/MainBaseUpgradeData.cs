using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBaseUpgradeData", menuName = "Upgrades/MainBase")]
public class MainBaseUpgradeData : ScriptableObject
{
    public MainBaseUpgradeLevelData[] Levels;
}