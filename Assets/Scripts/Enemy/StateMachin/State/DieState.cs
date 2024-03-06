using System;
using System.Collections;
using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(Animator), typeof(Enemy))]
    public class DieState : EnemyState
    {
        private const string Die = "Die";

        private float _delayBeforeDeath = 3f;
        private Animator _animator;
        private Enemy _enemy;
        private ParticleSystem _particleSystemDie;
        private WaitForSeconds _waitForSecounds;

        public event Action Died;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_delayBeforeDeath);
        }

        public void DieEnemy()
        {
            _animator.SetTrigger(Die);
            _particleSystemDie = Instantiate(_enemy.EnemyCard.ParticleSystemDie, transform.position, transform.rotation, transform);
            _particleSystemDie.Play();
            StartCoroutine(WaitForDieAnimationEnd());
            Died?.Invoke();
        }

        private IEnumerator WaitForDieAnimationEnd()
        {
            yield return _waitForSecounds;

            Destroy(_particleSystemDie.gameObject);
            gameObject.SetActive(false);
        }
    }
}