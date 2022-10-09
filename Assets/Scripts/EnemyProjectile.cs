using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : ProjectileStats
{
    void Start()
    {
        rb.AddForce(transform.up * projectileSpeed);
        Destroy(gameObject, 10);
    }

}
