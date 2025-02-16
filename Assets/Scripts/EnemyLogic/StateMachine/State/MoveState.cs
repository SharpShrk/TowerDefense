using System.Collections;
using Abilities;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyLogic.StateMachine.State
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveState : EnemyState
    {
        private FreezeEnemiesAbility _freezeEnemiesAbility;
        private float _freezeDuration;
        private float _defaultSpeed;
        private const string Run = "Run";
        private const float SpeedStart = 0.01f;
        private const float SpeedEnd = 0f;
        private float _frozenSpeed = 0f;
        private Coroutine _freeze;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            Animator.SetFloat(Run, SpeedStart);
            _agent.enabled = true;
            _defaultSpeed = _agent.speed;

            if (_freezeEnemiesAbility != null)
            {
                _freezeEnemiesAbility.EnemiesFreezed += OnEnemiesFreezed;
            }
        }

        private void OnDisable()
        {
            Animator.SetFloat(Run, SpeedEnd);
            _agent.speed = _defaultSpeed;
            _agent.enabled = false;
            StopFreezing();

            if (_freezeEnemiesAbility != null)
            {
                _freezeEnemiesAbility.EnemiesFreezed -= OnEnemiesFreezed;
            }
        }

        private void Update()
        {
            if (EnemyTarget != null)
            {
                _agent.SetDestination(Target.position);
            }
        }

        public void Init(FreezeEnemiesAbility freezeEnemiesAbility)
        {
            _freezeEnemiesAbility = freezeEnemiesAbility;
        }

        private void OnEnemiesFreezed(float freezeDuration)
        {
            _freezeDuration = freezeDuration;
            StopFreezing();
            _freeze = StartCoroutine(StartFreeze());
        }

        private void StopFreezing()
        {
            if (_freeze != null)
            {
                StopCoroutine(_freeze);
            }
        }

        private IEnumerator StartFreeze()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_freezeDuration);
            _agent.speed = _frozenSpeed;
            Animator.speed = 0;
            yield return waitForSeconds;
            _agent.speed = _defaultSpeed;
            Animator.speed = 1;
        }
    }
}