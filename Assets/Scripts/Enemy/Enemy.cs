using System;
using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Animator), typeof(EnemyHealth), typeof(Collider))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyState _firstState;
        [SerializeField] private DieState _dieState;
        [SerializeField] private EnemyCard _enemyCard;

        private EnemyState _currentState;
        private Animator _animator;
        private EnemyHealth _enemyHealth;
        private EnemyTarget _targetPoint;
        private Transform _target;
        private Collider _collider;

        public event Action<Enemy> Died;

        public EnemyState CurrentState => _currentState;

        public EnemyState DieState => _dieState;

        public EnemyCard EnemyCard => _enemyCard;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemyHealth = GetComponent<EnemyHealth>();
            _collider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            _enemyHealth.Died += OnEnemyDied;
        }

        private void OnDisable()
        {
            _enemyHealth.Died -= OnEnemyDied;
        }

        private void Start()
        {
            _currentState = _firstState;
            _currentState.Enter(_targetPoint, _animator, _target);
            _dieState.Enter(_targetPoint, _animator, _target);
        }

        private void Update()
        {
            foreach (var transition in _currentState.Transitions)
            {
                transition.enabled = true;
                transition.Init(_targetPoint, _target);
            }

            if (_currentState == null)
                return;

            EnemyState nextState = _currentState.GetNextState();

            if (nextState != null)
                Transit(nextState);
        }

        public void TransitFirstState()
        {
            Transit(_firstState);
            _currentState.Enter(_targetPoint, _animator, _target);
            _dieState.Enter(_targetPoint, _animator, _target);
        }

        public void Init(EnemyTarget targetPoint, Transform target)
        {
            _targetPoint = targetPoint;
            _target = target;
        }

        private void OnEnemyDied()
        {
            Died?.Invoke(this);
            enabled = false;
            _collider.enabled = false;
            Transit(_dieState);
            _dieState.DieEnemy();
        }

        private void Transit(EnemyState nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(_targetPoint, _animator, _target);
        }
    }
}