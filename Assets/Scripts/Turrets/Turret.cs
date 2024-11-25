using Buildings;
using EnemyLogic;
using GameResources;
using Interfaces;
using System.Collections;
using UnityEngine;

namespace Turrets
{
    public abstract class Turret : MonoBehaviour, IBuilding, IPoolable
    {
        [SerializeField] protected GameObject RotatingPlatform;
        [SerializeField] protected GameObject Gun;

        protected Transform ShootPoint;
        protected TurretData Data;
        protected BulletPool Pool;
        protected float AttackRange;
        protected float AttackCooldown;
        protected float CurrentAttackCooldown;
        protected float Damage;
        protected float RotationSpeed;

        public BuildType Type { get; protected set; }
        public bool IsPlaced { get; private set; }

        private void OnDisable()
        {
            Data.OnParametersUpdated -= SetParameters;
        }

        protected void Start()
        {
            Data = GetComponent<TurretData>();
            Data.OnParametersUpdated += SetParameters;

            IsPlaced = false;

            PlaceTurret();
        }

        public void SetPool(object pool)
        {
            Pool = pool as BulletPool;
        }

        public void PlaceTurret()
        {
            IsPlaced = true;
            gameObject.SetActive(true);

            SetParameters();

            StartCoroutine(Attack());
        }

        protected void SetParameters()
        {
            Data = GetComponent<TurretData>();

            AttackRange = Data.AttackRange;
            CurrentAttackCooldown = Data.AttackCooldown;
            Damage = Data.Damage;
            Type = Data.BuildingType;
            RotationSpeed = Data.RotationSpeed;
        }

        protected Enemy SearchAttackTarget()
        {
            Enemy closestEnemy = null;
            float closestDistanceSqr = AttackRange * AttackRange;

            Collider[] colliders = Physics.OverlapSphere(transform.position, AttackRange);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    float distanceToEnemySqr = (transform.position - collider.transform.position).sqrMagnitude;

                    if (distanceToEnemySqr < closestDistanceSqr)
                    {
                        closestDistanceSqr = distanceToEnemySqr;
                        closestEnemy = enemy;
                    }
                }
            }

            return closestEnemy;
        }

        protected void RotationGun(Enemy enemy)
        {
            Transform targetPoint = enemy.TargetShoot;

            Vector3 targetDirection = targetPoint.position - RotatingPlatform.transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion currentRotation = RotatingPlatform.transform.rotation;
            Vector3 currentRotationEuler = currentRotation.eulerAngles;
            float yRotation = targetRotation.eulerAngles.y;
            Vector3 newRotationEuler = new Vector3(currentRotationEuler.x, yRotation, currentRotationEuler.z);
            Quaternion newTargetRotation = Quaternion.Euler(newRotationEuler);
            RotatingPlatform.transform.rotation = Quaternion.Lerp(currentRotation, newTargetRotation, Time.deltaTime * RotationSpeed);

            Vector3 directionToTarget = targetPoint.position - Gun.transform.position;
            float yDifference = directionToTarget.y;
            float distanceToTarget = directionToTarget.magnitude;
            float angleToTarget = Mathf.Atan2(yDifference, distanceToTarget) * Mathf.Rad2Deg;
            angleToTarget = Mathf.Clamp(angleToTarget, -75f, 75f);

            Gun.transform.localRotation = Quaternion.Euler(-angleToTarget, 0, 0);
        }

        protected IEnumerator Attack()
        {
            while (IsPlaced)
            {
                var attackCooldown = new WaitForSeconds(CurrentAttackCooldown);
                Enemy target = SearchAttackTarget();

                if (target != null)
                {
                    RotationGun(target);
                    Shoot();
                }

                yield return attackCooldown;
            }
        }

        protected abstract void Shoot();
    }
}