using EnemyLogic;
using UnityEngine;

namespace GameLogic
{
    [System.Serializable]
    public class Wave
    {
        [SerializeField] private EnemyCount[] _enemyCounts;
        [SerializeField] private float _rate;
        [SerializeField] private Transform[] _wayPoints;

        public float Rate => _rate;

        public Transform[] WayPoints => _wayPoints;

        public EnemyCount[] EnemyCounts => _enemyCounts;
    }
}