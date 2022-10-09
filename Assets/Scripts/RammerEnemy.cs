using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RammerEnemy : GenericEnemy
{

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.Find("Player");

        GameObject[] playerWalls = GameObject.FindGameObjectsWithTag("PlayerWall");
        foreach (GameObject playerWall in playerWalls)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), playerWall.GetComponent<Collider2D>());
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Navigate();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("This ship has collided");
        
        if (collision.gameObject.tag == "Player" )
        {
            if (collision.gameObject.TryGetComponent(out PlayerMovement player))
            {

                player.TakeDamage(enemyDamage);
            }

            Instantiate(explosionEffect,transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
        }
    }


       
    



    protected override void Navigate()
    {
        agent.SetDestination(target.transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, agent.steeringTarget - transform.position);
        sprRend.gameObject.transform.rotation = Quaternion.Slerp(sprRend.gameObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

}
