using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCaliberTurret : Turret
{
    [SerializeField] private Transform _shootPoint;

    protected override void Shoot()
    {
        Bullet bullet = Pool.GetBullet();
        bullet.GetComponent<Bullet>().SetDamage((int)Damage);

        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;
    }
}
