using UnityEngine;

namespace EnemyLogic
{
    [System.Serializable]
    public class EnemyCount
    {
        [SerializeField] private EnemyCard _enemyCard;
        [SerializeField] private int _count;
        [SerializeField] private float _delay;

        public EnemyCard EnemyCard => _enemyCard;

        public int Count => _count;

        public float Delay => _delay;
    }
}