public class LargeCaliberBullet : Bullet
{
    private LargeCaliberBulletPool _bulletPool;

    public void Init(LargeCaliberBulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    protected override void ReturnToPool()
    {
        _bulletPool.ReturnBullet(gameObject);
    }
}