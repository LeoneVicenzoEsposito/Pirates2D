using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class ShooterEnemy : GenericEnemy
{

    private bool canShoot = true;

    public float shootingRange = 5f;

    public float timeBetweenShots = 3f;

    [SerializeField]
    private Object enemyProjectilePrefab, cannonFireFX;

    private GameObject enemyProjectile;

    public float enemyProjectileSpeed = 100f;

    private float cannonPositionOffset = 0.5f;

    public enum State
    {
        chase,
        atack
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.Find("Player");
        state = State.chase;
        enemyProjectile =  UpdateProjectileStats(enemyProjectilePrefab);

        GameObject[] playerWalls = GameObject.FindGameObjectsWithTag("PlayerWall");
        foreach (GameObject playerWall in playerWalls)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), playerWall.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            default:

            case State.chase:
                Navigate();
                if ((Vector3.Distance(transform.position, target.transform.position) < shootingRange) && canShoot)
                {
                    state = State.atack;
                }
                break;

            case State.atack:
                agent.speed = 0;
                if (canShoot)
                {
                    canShoot = false;
                    StartCoroutine(Shoot());
                }                          
                break;
            
        }
    }

    protected override void Navigate()
    {
        agent.SetDestination(target.transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, agent.steeringTarget - transform.position);
        sprRend.gameObject.transform.rotation = Quaternion.Slerp(sprRend.gameObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }



    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);

        Instantiate(enemyProjectile, sprRend.transform.position + (sprRend.transform.up * cannonPositionOffset), sprRend.transform.rotation);
        Instantiate(cannonFireFX, sprRend.transform.position + (sprRend.transform.up * cannonPositionOffset), sprRend.transform.rotation, sprRend.transform);
        state = State.chase;

        yield return new WaitForSeconds(timeBetweenShots);
        agent.speed = 1.5f;
        canShoot = true;
    }

     public GameObject UpdateProjectileStats(Object projectile)
    {
        GameObject projectGameObject = projectile as GameObject;
        EnemyProjectile enemyProjectileStats = projectGameObject.GetComponent<EnemyProjectile>();

        enemyProjectileStats.projectileDamage = enemyDamage;
        enemyProjectileStats.projectileSpeed = enemyProjectileSpeed;

        return projectGameObject;
    }

}
