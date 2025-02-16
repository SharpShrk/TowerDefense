using Bullets;
using UnityEngine;

namespace Turrets
{
    public class MachinegunTurret : Turret
    {
        [SerializeField] private Transform[] _shootPoints = new Transform[3];

        private int _currentShootPointIndex = 0;

        protected override void Shoot()
        {
            Bullet bullet = Pool.GetBullet();
            bullet.GetComponent<Bullet>().SetDamage((int)Damage);
            ShootPoint = _shootPoints[_currentShootPointIndex];
            bullet.transform.position = ShootPoint.position;
            bullet.transform.rotation = ShootPoint.rotation;
            _currentShootPointIndex = (_currentShootPointIndex + 1) % _shootPoints.Length;
            PlayShootSound();
        }
    }
}