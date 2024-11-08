using System;
using UnityEngine;

namespace Abilities
{
    public class IncreasedTurretDamageAbility : Ability
    {
        [SerializeField] private float _duration;

        private float _minDuration = 1;

        public event Action<float> DamageIncreased;

        private void OnValidate()
        {
            if (_duration < _minDuration)
                _duration = _minDuration;
        }

        public override void Activate()
        {
            base.Activate();
            DamageIncreased?.Invoke(_duration);
        }
    }
}