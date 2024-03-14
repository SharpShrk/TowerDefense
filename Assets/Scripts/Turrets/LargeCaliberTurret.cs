using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCaliberTurret : Turret
{
    [SerializeField] private Transform _shootPoint;

    protected override void Shoot()
    {
        GameObject bullet = Pool.GetBullet();
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage((int)Damage);
    }
}
