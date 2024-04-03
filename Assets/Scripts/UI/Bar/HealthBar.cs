using EnemyLogic;
using UnityEngine;

namespace Ui
{
    public class HealthBar : Bar
    {
        [SerializeField] private EnemyTargetHealth _enemyTargetHealth;

        private void OnEnable()
        {
            Slider.value = 1;
            _enemyTargetHealth.HealthChanged += OnValueChanger;
        }

        private void OnDisable()
        {
            _enemyTargetHealth.HealthChanged -= OnValueChanger;
        }
    }
}