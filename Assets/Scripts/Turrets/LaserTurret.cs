using UnityEngine;

namespace Turrets
{
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

            Bullet bullet = Pool.GetBullet();
            bullet.GetComponent<Bullet>().SetDamage((int)Damage);

            bullet.transform.position = ShootPoint.position;
            bullet.transform.rotation = ShootPoint.rotation;
        }
    }
}