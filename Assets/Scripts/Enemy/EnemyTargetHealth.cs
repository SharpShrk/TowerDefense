using Abilities;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyTargetHealth : HealthContainer
    {
        [SerializeField] private AddHealthBaseAbility _addHealthBaseAbility;

        private void OnEnable()
        {
            _addHealthBaseAbility.Cured += OnCured;
        }

        private void OnDisable()
        {
            _addHealthBaseAbility.Cured -= OnCured;
        }

        public void SetStartHealth(int startHealth)
        {
            Init(startHealth);
        }

        private void OnCured(int addedHealth)
        {
            AddHealth(addedHealth);
        }
    }
}