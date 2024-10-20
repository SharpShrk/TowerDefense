using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    [SerializeField] private Transform _shootPointLeft;
    [SerializeField] private Transform _shootPointRight;

    private bool _isLeftShootPointActive = true;

    protected override void Shoot()
    {
        if (_isLeftShootPointActive)
        {
            ShootPoint = _shootPointLeft;
            _isLeftShootPointActive = false;
        }
        else
        {
            ShootPoint = _shootPointRight;
            _isLeftShootPointActive = true;
        }

        GameObject bullet = Pool.GetBullet();
        bullet.transform.position = ShootPoint.position;
        bullet.transform.rotation = ShootPoint.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage((int)Damage);
    }
}