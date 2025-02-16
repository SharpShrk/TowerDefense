using System;
using Abilities;
using EnemyLogic.StateMachine.State;
using UnityEngine;
using Wallets;

namespace EnemyLogic
{
    [RequireComponent(typeof(Animator), typeof(EnemyHealth), typeof(Collider))]
    [RequireComponent(typeof(EnemyPointer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyState _firstState;
        [SerializeField] private DieState _dieState;
        [SerializeField] private EnemyCard _enemyCard;
        [SerializeField] private MoveState _moveState;
        [SerializeField] private Transform _targetShoot;
        [SerializeField] private AttackState _attackState;

        private int _damageDivider = 3;
        private EnemyState _currentState;
        private Animator _animator;
        private EnemyHealth _enemyHealth;
        private EnemyTarget _targetPoint;
        private Transform _target;
        private Score _score;
        private Collider _collider;
        private EnemyPointer _enemyPointer;
        private DestroyEnemiesAbility _destroyEnemiesAbility;
        private StrikeEnemiesAbility _strikeEnemiesAbility;

        public event Action<Enemy> Died;

        public EnemyState CurrentState => _currentState;

        public EnemyState DieState => _dieState;

        public EnemyCard EnemyCard => _enemyCard;

        public Transform TargetShoot => _targetShoot;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemyHealth = GetComponent<EnemyHealth>();
            _collider = GetComponent<Collider>();
            _enemyPointer = GetComponent<EnemyPointer>();
        }

        private void OnEnable()
        {
            if (_destroyEnemiesAbility != null)
            {
                _destroyEnemiesAbility.EnemiesDestroyed += OnEnemyDied;
            }

            if (_strikeEnemiesAbility != null)
            {
                _strikeEnemiesAbility.Striked += OnEnemyStriked;
            }

            if (_attackState != null)
            {
                _attackState.EnemieDestroyed += OnEnemyDestruction;
            }

            _enemyHealth.Died += OnEnemyDied;
        }

        private void OnDisable()
        {
            if (_destroyEnemiesAbility != null)
            {
                _destroyEnemiesAbility.EnemiesDestroyed -= OnEnemyDied;
            }

            if (_strikeEnemiesAbility != null)
            {
                _strikeEnemiesAbility.Striked -= OnEnemyStriked;
            }

            if (_attackState != null)
            {
                _attackState.EnemieDestroyed -= OnEnemyDestruction;
            }

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

        public void Init(EnemyTarget targetPoint,
            Transform target,
            Score score,
            DestroyEnemiesAbility destroyEnemiesAbility,
            FreezeEnemiesAbility freezeEnemiesAbility,
            StrikeEnemiesAbility strikeEnemiesAbility)
        {
            _targetPoint = targetPoint;
            _target = target;
            _score = score;
            _destroyEnemiesAbility = destroyEnemiesAbility;
            _strikeEnemiesAbility = strikeEnemiesAbility;
            _moveState.Init(freezeEnemiesAbility);
        }

        private void EnemyDied()
        {
            if (gameObject.activeSelf)
            {
                Died?.Invoke(this);
                enabled = false;
                _collider.enabled = false;
                Transit(_dieState);
                _dieState.DieEnemy();
                _enemyPointer.Destroy();
                _enemyHealth.ResetHealth();
            }
        }

        private void Transit(EnemyState nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(_targetPoint, _animator, _target);
        }

        private void OnEnemyDied()
        {
            EnemyDied();
            _score.AddScore(EnemyCard.Reward);
        }

        private void OnEnemyDestruction()
        {
            EnemyDied();
        }

        private void OnEnemyStriked()
        {
            if (gameObject.activeSelf)
                _enemyHealth.TakeDamage(_enemyHealth.MaxHealth / _damageDivider);
        }
    }
}