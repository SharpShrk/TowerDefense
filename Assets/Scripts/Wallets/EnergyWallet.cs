using System;
using UnityEngine;

public class EnergyWallet : MonoBehaviour
{
    [SerializeField] private int _startEnergyValue;

    private int _energyValue;
    private int _maxEnergyValue = 100;

    public event Action<int> OnEnergyValueChanged;

    public int EnergyValue => _energyValue;

    private void Start()
    {
        SetStartValue(_startEnergyValue);
    }

    private void SetStartValue(int value)
    {
        _energyValue = value;
        OnEnergyValueChanged?.Invoke(_energyValue);
    }

    public void AddEnergy(int amount)
    {
        _energyValue += amount;

        if (_energyValue >= _maxEnergyValue)
        {
            _energyValue = _maxEnergyValue;
        }

        OnEnergyValueChanged?.Invoke(_energyValue);
    }

    public bool SpendEnergy(int amount)
    {
        if (_energyValue < amount)
        {
            return false;
        }

        _energyValue -= amount;
        OnEnergyValueChanged?.Invoke(_energyValue);

        return true;
    }
}
