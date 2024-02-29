using EnemyLogic;
using UnityEngine;

namespace GameLogic
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private EnemyCount[] _enemyCounts;
        [SerializeField] private Transform _startPoint;

        public Transform StartPoint => _startPoint;

        public EnemyCount[] EnemyCounts => _enemyCounts;
    }
}