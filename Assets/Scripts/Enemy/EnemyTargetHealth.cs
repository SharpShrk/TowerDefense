using UnityEngine;

namespace EnemyLogic
{
    public class EnemyTargetHealth : HealthContainer
    {
        [SerializeField] private int _maxHealthTarget;

        private void Awake()
        {
            Init(_maxHealthTarget);
        }
    }
}