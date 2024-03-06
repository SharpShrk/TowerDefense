using System.Collections;
using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Enemy))]
    public class AttackState : EnemyState
    {
        private const string Attack = "Attack";

        private Enemy _enemy;
        private Coroutine _attackCoroutine;
        private WaitForSeconds _waitForSecounds;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            if (enabled)
                StartAttack();
        }

        private void OnDisable()
        {
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
            }
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_enemy.EnemyCard.AttackSpeed);
        }

        private void StartAttack()
        {
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
            }

            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            Animator.SetTrigger(Attack);
            EnemyTarget.GetComponent<EnemyTargetHealth>().TakeDamage(_enemy.EnemyCard.Damage);
            yield return _waitForSecounds;

            if (EnemyTarget.IsAlive())
                StartAttack();
        }
    }
}