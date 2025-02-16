using EnemyLogic;
using UnityEngine;

namespace UI.Bars
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