using Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameResources
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _initialPoolSize = 30;
        [SerializeField] private int _maxPoolSize = 100;
        [SerializeField] private GameObject _bulletContainer;
        [SerializeField] private IncreasedTurretDamageAbility _increasedTurretDamageAbility;

        private Queue<Bullet> _bulletPoolQueue;
        private float _duration;
        private Coroutine _increaseDamage;

        private void Awake()
        {
            InitializePool();
            _increasedTurretDamageAbility.DamageIncreased += OnDamageIncreased;
        }

        private void OnDisable()
        {
            _increasedTurretDamageAbility.DamageIncreased -= OnDamageIncreased;
            StopIncreaseDamage();
        }

        private void InitializePool()
        {
            _bulletPoolQueue = new Queue<Bullet>();

            for (int i = 0; i < _initialPoolSize; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab);
                bullet.gameObject.SetActive(false);
                bullet.transform.SetParent(_bulletContainer.transform);
                bullet.GetComponent<Bullet>().Init(this);
                _bulletPoolQueue.Enqueue(bullet);
            }
        }

        public Bullet GetBullet()
        {
            if (_bulletPoolQueue.Count > 0)
            {
                Bullet bullet = _bulletPoolQueue.Dequeue();
                bullet.gameObject.SetActive(true);
                return bullet;
            }

            if (_bulletPoolQueue.Count + 1 <= _maxPoolSize)
            {
                Bullet newBullet = Instantiate(_bulletPrefab, _bulletContainer.transform);
                newBullet.GetComponent<Bullet>().Init(this);
                return newBullet;
            }
            return null;
        }

        public void ReturnBullet(Bullet bullet)
        {
            if (_bulletPoolQueue.Count < _maxPoolSize)
            {
                bullet.transform.position = Vector3.zero;
                bullet.transform.rotation = Quaternion.identity;

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = Vector3.zero;
                    bulletRigidbody.angularVelocity = Vector3.zero;
                }

                bullet.gameObject.SetActive(false);
                _bulletPoolQueue.Enqueue(bullet);
            }
            else
            {
                Destroy(bullet);
            }
        }

        private void SetDefaultBulletDamage()
        {
            foreach (var bullet in _bulletPoolQueue)
            {
                bullet.SetDefaultDamage();
            }
        }

        private void IncreaseBulletDamage()
        {
            foreach (var bullet in _bulletPoolQueue)
            {
                bullet.IncreaseDamage();
            }
        }

        private void StopIncreaseDamage()
        {
            if (_increaseDamage != null)
            {
                StopCoroutine(_increaseDamage);
            }
        }

        private IEnumerator IncreaseDamage()
        {
            var waitForSecond = new WaitForSeconds(_duration);
            IncreaseBulletDamage();
            yield return waitForSecond;
            SetDefaultBulletDamage();
            StopIncreaseDamage();
        }

        private void OnDamageIncreased(float duration)
        {
            _duration = duration;
            _increaseDamage = StartCoroutine(IncreaseDamage());
        }
    }
}