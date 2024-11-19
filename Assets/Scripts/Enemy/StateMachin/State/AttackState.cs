using System;
using System.Collections;
using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Enemy))]
    public class AttackState : EnemyState
    {
        private const string Attack = "Attack";

        private Enemy _enemy;
        private WaitForSeconds _waitForSecounds;

        public event Action EnemieDestroyed;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnDisable()
        {
            StopCoroutine(WaitForDieAnimationEnd());
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_enemy.EnemyCard.AttackSpeed);
            AttackTarget();
        }

        private void AttackTarget()
        {
            Animator.SetTrigger(Attack);
            EnemyTarget.GetComponent<EnemyTargetHealth>().TakeDamage(_enemy.EnemyCard.Damage);
            StartCoroutine(WaitForDieAnimationEnd());
        }

        private IEnumerator WaitForDieAnimationEnd()
        {
            yield return _waitForSecounds;
            EnemieDestroyed?.Invoke();
        }
    }
}