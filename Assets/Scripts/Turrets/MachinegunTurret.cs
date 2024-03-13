using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunTurret : Turret
{
    [SerializeField] private MachinegunBulletPool _pool;
    [SerializeField] private Transform[] _shootPoints = new Transform[3];    

    private int _currentShootPointIndex = 0;

    /*protected override void Init(LaserBulletPool bulletPool)
    {
        _pool = bulletPool;
    }*/
    private void OnEnable()
    {
        Type = BuildType.MachineGun;
    }

    protected override void Shoot()
    {
        GameObject bullet = _pool.GetBullet();

        ShootPoint = _shootPoints[_currentShootPointIndex];

        bullet.transform.position = ShootPoint.position;
        bullet.transform.rotation = ShootPoint.rotation;

        _currentShootPointIndex = (_currentShootPointIndex + 1) % _shootPoints.Length;

        MachinegunBullet bulletScript = bullet.GetComponent<MachinegunBullet>();
        bulletScript.SetDamage((int)Damage);
    }
}
