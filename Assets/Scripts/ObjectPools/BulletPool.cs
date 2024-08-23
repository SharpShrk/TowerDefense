using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _initialPoolSize = 30;
    [SerializeField] private int _maxPoolSize = 100;
    [SerializeField] private GameObject _bulletContainer;

    private Queue<GameObject> _bulletPoolQueue;

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        _bulletPoolQueue = new Queue<GameObject>();

        for (int i = 0; i < _initialPoolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            bullet.transform.SetParent(_bulletContainer.transform);
            bullet.GetComponent<Bullet>().Init(this);

            _bulletPoolQueue.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (_bulletPoolQueue.Count > 0)
        {
            GameObject bullet = _bulletPoolQueue.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }

        if (_bulletPoolQueue.Count + 1 <= _maxPoolSize)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, _bulletContainer.transform);
            newBullet.GetComponent<Bullet>().Init(this);
            return newBullet;
        }

        Debug.Log("ѕревышен максимальный размер пула пуль");
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        if (_bulletPoolQueue.Count < _maxPoolSize)
        {
            bullet.SetActive(false);
            _bulletPoolQueue.Enqueue(bullet);
        }
        else
        {
            Destroy(bullet);
            Debug.Log("ѕул€ уничтожена, так как пул переполнен");
        }
    }
}
