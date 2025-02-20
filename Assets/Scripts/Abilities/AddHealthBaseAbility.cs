using System;
using UnityEngine;

namespace Abilities
{
    public class AddHealthBaseAbility : Ability
    {
        [SerializeField] private int _addedHealth;

        private int _minAddedHealth = 100;

        public event Action<int> Cured;

        private void OnValidate()
        {
            if (_addedHealth < _minAddedHealth)
                _addedHealth = _minAddedHealth;
        }

        public override void Activate()
        {
            base.Activate();
            Cured?.Invoke(_addedHealth);
        }
    }
}