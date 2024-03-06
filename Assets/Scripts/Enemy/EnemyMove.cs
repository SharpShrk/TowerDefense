using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _targer;
        private int _wavePointIndex;
        private Transform[] _wayPoints;
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            Vector3 direction = _targer.position - transform.position;
            transform.Translate(_speed * Time.deltaTime * direction.normalized);
            transform.LookAt(_targer.position);

            if (Vector3.Distance(transform.position, _targer.position) <= 0.4f)
            {
                GetNextWayPoint();
            }

            //_enemy.ResetSpeed();
        }

        public void Init(Transform[] wayPoints)
        {
            _wayPoints = wayPoints;
            _targer = wayPoints[0];
        }

        private void GetNextWayPoint()
        {
            if (_wavePointIndex >= _wayPoints.Length - 1)
            {
                EndPath();
                return;
            }

            _wavePointIndex++;
            _targer = _wayPoints[_wavePointIndex];
        }

        private void EndPath()
        {
            //_enemy.Die();
        }
    }
}