using System;
using UnityEngine;

public class MetalWallet : MonoBehaviour
{
    [SerializeField] private int _startMetalValue;

    private int _metalValue;

    public event Action<int> OnMetalValueChanged;

    public int MetalValue => _metalValue;

    private void Start()
    {
        SetStartValue(_startMetalValue);
    }

    private void SetStartValue(int value)
    {
        _metalValue = value;
        OnMetalValueChanged?.Invoke(_metalValue);
    }

    public void AddMetal(int amount)
    {
        _metalValue += amount;
        OnMetalValueChanged?.Invoke(_metalValue);
    }

    public bool SpendMetal(int amount)
    {
        if (_metalValue < amount)
        {
            return false;
        }

        _metalValue -= amount;
        OnMetalValueChanged?.Invoke(_metalValue);

        return true;
    }
}
