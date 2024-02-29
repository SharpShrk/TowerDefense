using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class DieState : EnemyState
    {
        private const string Die = "Die";

        private float _delayBeforeDeath = 3f;
        private Animator _animator;
        private WaitForSeconds _waitForSecounds;

        public event Action Died;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_delayBeforeDeath);
        }

        public void DieEnemy()
        {
            //Vector3 impactDirection = (attachedBody.position - transform.position).normalized;
            _animator.SetTrigger(Die);
            //_rigidbody.AddForce(impactDirection * force, ForceMode.Impulse);
            StartCoroutine(WaitForDieAnimationEnd());
            Died?.Invoke();
        }

        private IEnumerator WaitForDieAnimationEnd()
        {
            yield return _waitForSecounds;

            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}