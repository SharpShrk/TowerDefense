using System;
using UnityEngine;

namespace Abilities
{
    public class FreezeEnemiesAbility : Ability
    {
        [SerializeField] private float _duration;

        private float _minDuration = 2;

        public event Action<float> EnemiesFreezed;

        private void OnValidate()
        {
            if (_duration < _minDuration)
                _duration = _minDuration;
        }

        public override void Activate()
        {
            base.Activate();
            EnemiesFreezed?.Invoke(_duration);
        }
    }
}