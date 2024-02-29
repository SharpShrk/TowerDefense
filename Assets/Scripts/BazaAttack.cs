using System.Collections;
using System.Collections.Generic;
using EnemyLogic;
using UnityEngine;

public class BazaAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
    }


}
