using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Bullet
{
    private LaserBulletPool _bulletPool;

    public void Init(LaserBulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    protected override void ReturnToPool()
    {
        _bulletPool.ReturnBullet(gameObject);
    }
}