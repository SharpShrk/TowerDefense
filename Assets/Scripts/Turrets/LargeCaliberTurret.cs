using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCaliberTurret : Turret
{
    [SerializeField] private LargeCaliberBulletPool _pool;
    [SerializeField] private Transform _shootPoint;

    /*protected override void Init(LaserBulletPool bulletPool)
{
    _pool = bulletPool;
}*/

    protected override void Shoot()
    {
        GameObject bullet = _pool.GetBullet();
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;

        LargeCaliberBullet bulletScript = bullet.GetComponent<LargeCaliberBullet>();
        bulletScript.SetDamage((int)Damage);
    }
}
