using System;
using UnityEngine;

namespace Wallets
{
    public abstract class ResourceWallet : MonoBehaviour
    {
        [SerializeField] private int _startValue;

        private int _currentValue;

        public event Action<int> ValueChanged;

        public int CurrentValue => _currentValue;

        protected virtual void Start()
        {
            SetStartValue(_startValue);
        }

        private void SetStartValue(int value)
        {
            _currentValue = value;
            ValueChanged?.Invoke(_currentValue);
        }

        public void AddResource(int amount)
        {
            _currentValue += amount;
            ValueChanged?.Invoke(_currentValue);
        }

        public bool SpendResource(int amount)
        {
            if (_currentValue < amount)
            {
                return false;
            }

            _currentValue -= amount;
            ValueChanged?.Invoke(_currentValue);
            return true;
        }
    }
}