using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerHP;
    public HealthBar healthBar;

    public float  playerTurnRate;

    public int playerMaxSpeed;
    public float playerTorque;

    private float forwardMovement;
    private float turningMovement;
    private Vector2 accelerationForce;
    private float rotationForce;

    [SerializeField]
    private Rigidbody2D rb;


    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    public List<Sprite> playerSprites;

    [SerializeField]
    private GameObject playerExplosionEffect;


    [SerializeField]
    private GameObject endGameMenu;



    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(playerHP);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forwardMovement  = -1 * Input.GetAxis("Vertical") * playerTorque;
        turningMovement = Input.GetAxis("Horizontal") * playerTurnRate;

        accelerationForce = -transform.up * forwardMovement;
        rotationForce = -turningMovement;  


        if (Input.GetAxis("Vertical") != 0) {
            rb.AddForce(accelerationForce, ForceMode2D.Force); 
        }
        if (Input.GetAxis("Horizontal") != 0) {
            rb.AddTorque(rotationForce, ForceMode2D.Force); 
        }


    }

    public void TakeDamage(int damageToBeTaken)
    {
        playerHP -= damageToBeTaken;
        

        if (playerHP <= 0)
        {
            healthBar.SetHealth(0);
            playerSpriteRenderer.sprite = playerSprites[0];
            Instantiate(playerExplosionEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject, 0.01f);
            endGameMenu.SetActive(true);

            playerTorque = 0;
            rotationForce = 0;

            PlayerMovement playerMovemet = GetComponent<PlayerMovement>();
            PlayerFire playerFire = GetComponent<PlayerFire>();
            playerFire.enabled = false;
            playerMovemet.enabled = false;

        }
        else
        {
            UpdateVisuals();
            healthBar.SetHealth(playerHP);
        }
    }

    void UpdateVisuals()
    {
        playerSpriteRenderer.sprite = playerSprites[playerHP];
    }
}
