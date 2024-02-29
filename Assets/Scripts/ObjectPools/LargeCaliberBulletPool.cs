using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCaliberBulletPool : BulletPool
{
    protected override void InitializePool()
    {
        BulletPoolQueue = new Queue<GameObject>();

        for (int i = 0; i < InitialPoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.GetComponent<LargeCaliberBullet>().Init(this);

            bullet.SetActive(false);
            bullet.transform.SetParent(BulletContainer.transform);
            BulletPoolQueue.Enqueue(bullet);
        }
    }
}
