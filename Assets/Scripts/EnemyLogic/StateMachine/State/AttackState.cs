using System;
using System.Collections;
using UnityEngine;

namespace EnemyLogic.StateMachine.State
{
    [RequireComponent(typeof(Enemy))]
    public class AttackState : EnemyState
    {
        private const string Attack = "Attack";

        private Enemy _enemy;
        private WaitForSeconds _waitForSecounds;
        private Coroutine _coroutine;

        public event Action EnemieDestroyed;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _waitForSecounds = new WaitForSeconds(_enemy.EnemyCard.AttackSpeed);
        }

        private void OnEnable()
        {
            AttackTarget();
        }

        private void OnDisable()
        {
           StopCoroutineDie();
        }

        private void AttackTarget()
        {
            Animator.SetTrigger(Attack);
            EnemyTarget.GetComponent<EnemyTargetHealth>().TakeDamage(_enemy.EnemyCard.Damage);
            StopCoroutineDie();
            _coroutine = StartCoroutine(WaitForDieAnimationEnd());
        }

        private IEnumerator WaitForDieAnimationEnd()
        {
            yield return _waitForSecounds;
            EnemieDestroyed?.Invoke();
        }

        private void StopCoroutineDie()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }
}