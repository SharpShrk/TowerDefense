using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunTurret : Turret
{
    [SerializeField] private Transform[] _shootPoints = new Transform[3];    

    private int _currentShootPointIndex = 0;

    protected override void Shoot()
    {
        GameObject bullet = Pool.GetBullet();

        ShootPoint = _shootPoints[_currentShootPointIndex];

        bullet.transform.position = ShootPoint.position;
        bullet.transform.rotation = ShootPoint.rotation;

        _currentShootPointIndex = (_currentShootPointIndex + 1) % _shootPoints.Length;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage((int)Damage);
    }
}
