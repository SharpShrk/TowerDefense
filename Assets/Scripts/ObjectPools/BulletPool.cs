using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPool : MonoBehaviour
{
    [SerializeField] protected GameObject BulletPrefab;
    [SerializeField] protected int InitialPoolSize = 30;
    [SerializeField] protected GameObject BulletContainer;

    protected Queue<GameObject> BulletPoolQueue;

    protected void Awake()
    {
        InitializePool();
    }

    public GameObject GetBullet()
    {
        if (BulletPoolQueue.Count > 0)
        {
            GameObject bullet = BulletPoolQueue.Dequeue();
            bullet.SetActive(true);
            bullet.transform.SetParent(BulletContainer.transform);

            return bullet;
        }

        GameObject newBullet = Instantiate(BulletPrefab);
        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        BulletPoolQueue.Enqueue(bullet);
    }

    protected abstract void InitializePool();
}