using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyLogic
{
    [RequireComponent(typeof(EnemyTargetHealth))]
    public class EnemyTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] _pointsAttack;
        [SerializeField] private ParticleSystem _particleSystemExplosion;

        private EnemyTargetHealth _enemyTargetHealth;
        private float _delayDeath = 3f;
        private WaitForSeconds _waitForSecounds;

        public event Action Died;

        private void Awake()
        {
            _enemyTargetHealth = GetComponent<EnemyTargetHealth>();
        }

        private void OnEnable()
        {
            _enemyTargetHealth.Died += OnDied;
        }

        private void OnDisable()
        {
            _enemyTargetHealth.Died -= OnDied;
        }

        private void Start()
        {
            _waitForSecounds = new WaitForSeconds(_delayDeath);
        }

        public Transform GetPoint()
        {
            int indexPoint = Random.Range(0, _pointsAttack.Length);
            return _pointsAttack[indexPoint];
        }

        private void OnDied()
        {
            Instantiate(_particleSystemExplosion, transform.position, Quaternion.identity);
            Died?.Invoke();
            StartCoroutine(WaitForDie());
        }

        private IEnumerator WaitForDie()
        {
            yield return _waitForSecounds;

            Died?.Invoke();
            _particleSystemExplosion.Stop();
        }
    }
}