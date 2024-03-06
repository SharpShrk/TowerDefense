public class MachinegunBullet : Bullet
{
    private MachinegunBulletPool _bulletPool;

    public void Init(MachinegunBulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    protected override void ReturnToPool()
    {
        _bulletPool.ReturnBullet(gameObject);
    }
}