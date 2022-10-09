using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileStats : MonoBehaviour
{
    public string targetTag;

    public int projectileDamage;

    public float projectileSpeed;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == targetTag) || (collision.tag == "Obstacle"))
        {

            if (collision.TryGetComponent(out GenericEnemy enemyShip))
            {
                enemyShip.TakeDamage(projectileDamage);
            }

            if (collision.TryGetComponent(out PlayerMovement playerShip))
            {
                playerShip.TakeDamage(projectileDamage);
            }

            Destroy(gameObject);
        }

    }
}
