using UnityEngine;

namespace EnemyLogic
{
    [System.Serializable]
    public class EnemyCount
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private int _count;
        [SerializeField] private float _delay;

        public Enemy Enemy => _enemy;

        public int Count => _count;

        public float Delay => _delay;
    }
}