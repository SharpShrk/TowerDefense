using System;
using UnityEngine;

public class EnergyWallet : MonoBehaviour
{
    [SerializeField] private int _startEnergyValue;

    private int _energyValue;
    private int _maxEnergyValue = 100;

    public event Action<int> EnergyValueChanged;

    public int EnergyValue => _energyValue;

    private void Start()
    {
        SetStartValue(_startEnergyValue);
    }

    private void SetStartValue(int value)
    {
        _energyValue = value;
        EnergyValueChanged?.Invoke(_energyValue);
    }

    public void AddEnergy(int amount)
    {
        _energyValue += amount;
        EnergyValueChanged?.Invoke(_energyValue);
    }

    public bool SpendEnergy(int amount)
    {
        if (_energyValue < amount)
        {
            return false;
        }

        _energyValue -= amount;
        EnergyValueChanged?.Invoke(_energyValue);

        return true;
    }
}
