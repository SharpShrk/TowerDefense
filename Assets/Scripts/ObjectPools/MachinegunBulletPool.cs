using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunBulletPool : BulletPool
{
    protected override void InitializePool()
    {
        BulletPoolQueue = new Queue<GameObject>();

        for (int i = 0; i < InitialPoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.GetComponent<MachinegunBullet>().Init(this);

            bullet.SetActive(false);
            bullet.transform.SetParent(BulletContainer.transform);
            BulletPoolQueue.Enqueue(bullet);
        }
    }
}
