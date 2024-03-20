using EnemyLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour, IBuilding, IPoolable
{
    [SerializeField] protected GameObject RotatingPlatform;
    [SerializeField] protected GameObject Gun;

    protected Transform ShootPoint;
    protected TurretData Data;
    protected GameObject Target;
    protected BulletPool Pool;
    protected float AttackRange;
    protected float AttackCooldown;
    protected float CurrentAttackCooldown;
    protected float Damage;
    protected float RotationSpeed;

    public BuildType Type { get; private set; }
    public bool IsPlaced { get; private set; }

    protected void Start()
    {
        Data = GetComponent<TurretData>();

        IsPlaced = false;

        PlaceTurret(); //временное решение для инициализации
        AttackRange = Data.AttackRange;
        CurrentAttackCooldown = Data.AttackCooldown;
        Damage = Data.Damage;
        Type = Data.Type;
        RotationSpeed = Data.RotationSpeed;
    }

    public void SetPool(object pool)
    {
        Pool = pool as BulletPool;
    }

    public void PlaceTurret()
    {
        IsPlaced = true;
        gameObject.SetActive(true);
        StartCoroutine(Attack());
    }

    public void SetAttackSpeed(float attackSpeedMultiplier)
    {
        CurrentAttackCooldown = AttackCooldown * attackSpeedMultiplier;
    }

    public void SetUpgradeDamage(float damage)
    {
        Damage = damage;
    }

    protected GameObject SearchAttackTarget()
    {
        Target = null;
        float closestDistance = AttackRange;

        /*int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, AttackRange, hitColliders);

        for(int i = 0; i < numColliders; i++)
        {
            
            if (hitColliders[i].TryGetComponent<Enemy>(out var enemy))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, hitColliders[i].transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    Target = hitColliders[i].gameObject;
                }
            }
        }*/

        Collider[] colliders = Physics.OverlapSphere(transform.position, AttackRange);

        float closestDistanceSqr = AttackRange * AttackRange;

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                float distanceToEnemySqr = (transform.position - collider.transform.position).sqrMagnitude;

                if (distanceToEnemySqr < closestDistanceSqr)
                {
                    closestDistanceSqr = distanceToEnemySqr;
                    Target = collider.gameObject;
                }
            }
        }

        return Target;
    }

    protected void RotationGun(GameObject target)
    {
        Vector3 targetDirection = target.transform.position - RotatingPlatform.transform.position;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion currentRotation = RotatingPlatform.transform.rotation;
        Vector3 currentRotationEuler = currentRotation.eulerAngles;
        float yRotation = targetRotation.eulerAngles.y;
        Vector3 newRotationEuler = new Vector3(currentRotationEuler.x, yRotation, currentRotationEuler.z);
        Quaternion newTargetRotation = Quaternion.Euler(newRotationEuler);
        RotatingPlatform.transform.rotation = Quaternion.Lerp(currentRotation, newTargetRotation, Time.deltaTime * RotationSpeed);

        Vector3 directionToTarget = target.transform.position - Gun.transform.position;
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
            GameObject target = SearchAttackTarget();

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