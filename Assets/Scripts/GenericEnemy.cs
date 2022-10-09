using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GenericEnemy : MonoBehaviour
{
    [SerializeField]
    protected HealthBar healthBar;
    public int HP = 3;

    public int enemyDamage = 1;

    public float rotationSpeed = 5;
    protected GameObject target;
    protected NavMeshAgent agent;

    [SerializeField]
    protected SpriteRenderer sprRend;
    public List<Sprite> sprites;

    [SerializeField]
    protected GameObject explosionEffect;

    [SerializeField]
    protected int scoreValue = 1;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Navigate();
    }

    public virtual void TakeDamage(int dmg)
    {
        HP = HP - dmg;

        if (HP <= 0)
        {
            sprRend.sprite = sprites[0];
            healthBar.SetHealth(0);
            Destroy(gameObject, 0.01f);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Score.instance.AddPoints(scoreValue);
            return;
        }
        else
        {
            healthBar.SetHealth(HP);
            UpdateVisuals();
            return;
        }
    }

    protected virtual void UpdateVisuals()
    {
        sprRend.sprite = sprites[HP];
    }

    protected abstract void Navigate();

}
