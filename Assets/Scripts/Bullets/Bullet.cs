using System.Collections;
using EnemyLogic;
using ObjectPools;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _defaultDamage = 10;
        [SerializeField] private float _splashDamageMultiplier;
        [SerializeField] private bool _hasSplashDamage = false;
        [SerializeField] private float _splashRadius = 5f;

        private int _damage;
        private int _splashDamage;
        private Rigidbody _rigidbody;
        private BulletPool _bulletPool;
        private bool _isIncreasedDamage = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _damage = _defaultDamage;
            _splashDamage = (int)(_damage * _splashDamageMultiplier);
        }

        private void OnEnable()
        {
            StartCoroutine(DisableBulletAfterTime());
        }

        private void FixedUpdate()
        {
            Vector3 direction = transform.forward;
            Vector3 movement = direction.normalized * _speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(transform.position + movement);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageable = collision.gameObject.GetComponent<EnemyHealth>();

            if (damageable != null)
            {
                damageable.TakeDamage(_damage);

                if (_hasSplashDamage)
                {
                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, _splashRadius);
                    foreach (Collider hitCollider in hitColliders)
                    {
                        if (hitCollider.gameObject != collision.gameObject && hitCollider.TryGetComponent<EnemyHealth>(out EnemyHealth nearbyEnemy))
                        {
                            nearbyEnemy.TakeDamage(_splashDamage);
                        }
                    }
                }
            }

            ReturnToPool();
        }

        public void Init(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public void SetDamage(int damage)
        {
            if (_isIncreasedDamage)
            {
                _damage = damage * 2;
            }
            else
            {
                _damage = damage;
            }

            _splashDamage = (int)(_damage * _splashDamageMultiplier);
        }

        private IEnumerator DisableBulletAfterTime()
        {
            yield return new WaitForSeconds(_lifetime);
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            _bulletPool.ReturnBullet(this);
        }

        public void IncreaseDamage()
        {
            _isIncreasedDamage = true;
        }

        public void SetDefaultDamage()
        {
            _isIncreasedDamage = false;
        }
    }
}