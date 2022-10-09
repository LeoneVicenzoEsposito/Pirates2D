using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : ProjectileStats
{
    void Start()
    {
        Destroy(gameObject, 10);
        rb.AddForce(transform.up * projectileSpeed);
    }
}
