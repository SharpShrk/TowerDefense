using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BuildingData : MonoBehaviour
{
    [SerializeField] protected int Level;
    [SerializeField] protected int CostUpgrade;
    [SerializeField] protected string Label;
    //[SerializeField] private Image Icon;
    [SerializeField] protected BuildType Type;
    [SerializeField] protected GameObject Prefab;

    protected int MaxLevel = 3;

    public int BuidlingLevel => Level;
    public int BuidingMaxLevel => MaxLevel;
    public int BuildinCostUpgrade => CostUpgrade;
    public string BuidlingLabel => Label;
    public BuildType BuildingType => Type;
    public GameObject BuildingPrefab => Prefab;
    //public Image BuildingIcon => Icon;

    public void LevelUp(int level)
    {
        if (level <= MaxLevel)
        {
            Level++;
            ApplyUpgrade(level);
        }
    }

    protected abstract void ApplyUpgrade(int level);
}