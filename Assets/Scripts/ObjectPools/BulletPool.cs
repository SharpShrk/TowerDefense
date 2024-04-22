using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private int InitialPoolSize = 30;
    [SerializeField] private GameObject BulletContainer;

    private Queue<GameObject> BulletPoolQueue;

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        BulletPoolQueue = new Queue<GameObject>();

        for (int i = 0; i < InitialPoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.GetComponent<Bullet>().Init(this);

            bullet.SetActive(false);
            bullet.transform.SetParent(BulletContainer.transform);
            BulletPoolQueue.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (BulletPoolQueue.Count > 0)
        {
            GameObject bullet = BulletPoolQueue.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }

        GameObject newBullet = Instantiate(BulletPrefab, BulletContainer.transform);
        Bullet bulletComponent = newBullet.GetComponent<Bullet>();

        if (bulletComponent != null)
        {
            bulletComponent.Init(this);
        }

        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        BulletPoolQueue.Enqueue(bullet);
    }
}