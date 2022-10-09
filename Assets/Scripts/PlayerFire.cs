using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public int broadsideExtraProjectileCount = 1;

    [HideInInspector] 
    public float frontalProjectileSpread = 3;
    public float broadsideProjectileSpread = 3;

    public float playerFrontalFirerrate = 3;
    public float playerBroadsideFirerate = 3;

    public int playerProjectileDamage = 1;
    public float playerProjectileSpeed = 100f;

    private float cannonPositionOffset = 0.21f;

    public GameObject cannonBall;
    public GameObject cannonFireFX;

    private bool canFireFrontal = true;
    private bool canBroadside = true;

    // Start is called before the first frame update
    void Start()
    {
        cannonBall = UpdateProjectileStats(cannonBall);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if ((Input.GetButton("Fire1")) && canBroadside){

            

            for (float i = 0; i <= broadsideExtraProjectileCount; i++)
            {
                Vector3 shotOrigin = transform.up;
                float offsetMagnitude = i * broadsideProjectileSpread;

                Vector3 shootingOffset = (shotOrigin * (offsetMagnitude));

                Vector3 rightCannonPosition = transform.position - transform.right * cannonPositionOffset;
                Vector3 leftCannonPosition = transform.position + transform.right * cannonPositionOffset;

                if (i == 0)
                {
                    Instantiate(cannonBall, transform.position - (transform.right * cannonPositionOffset), transform.rotation * Quaternion.Euler(0, 0, 90));
                    Instantiate(cannonBall, transform.position + (transform.right * cannonPositionOffset), transform.rotation * Quaternion.Euler(0, 0, -90));
                    Instantiate(cannonFireFX, transform.position - (transform.right * cannonPositionOffset), transform.rotation * Quaternion.Euler(0, 0, 90), transform);
                    Instantiate(cannonFireFX, transform.position + (transform.right * cannonPositionOffset), transform.rotation * Quaternion.Euler(0, 0, -90), transform);
                }
                else
                {
                    Instantiate(cannonBall, rightCannonPosition + shootingOffset, transform.rotation * Quaternion.Euler(0, 0, 90));
                    Instantiate(cannonBall, rightCannonPosition - shootingOffset, transform.rotation * Quaternion.Euler(0, 0, 90));
                    Instantiate(cannonFireFX, rightCannonPosition + shootingOffset, transform.rotation * Quaternion.Euler(0, 0, 90), transform);
                    Instantiate(cannonFireFX, rightCannonPosition - shootingOffset, transform.rotation * Quaternion.Euler(0, 0, 90), transform);

                    Instantiate(cannonBall, leftCannonPosition + shootingOffset, transform.rotation * Quaternion.Euler(0, 0, -90));
                    Instantiate(cannonBall, leftCannonPosition - shootingOffset, transform.rotation * Quaternion.Euler(0, 0, -90));
                    Instantiate(cannonFireFX, leftCannonPosition + shootingOffset, transform.rotation * Quaternion.Euler(0, 0, -90), transform);
                    Instantiate(cannonFireFX, leftCannonPosition - shootingOffset, transform.rotation * Quaternion.Euler(0, 0, -90), transform);

                }

            }
            canBroadside = false;
            StartCoroutine(BroadsideFireCooldown());
        }


       if ((Input.GetButton("Fire2")) && canFireFrontal){
            Instantiate(cannonBall, transform.position + (transform.up * 2 * cannonPositionOffset) , transform.rotation);
            Instantiate(cannonBall, transform.position + (transform.up * 2 * cannonPositionOffset), transform.rotation);
            canFireFrontal = false;
            StartCoroutine(FrontalFireCooldown());
        }
    }

    IEnumerator BroadsideFireCooldown()
    {
        yield return new WaitForSeconds((2f / playerBroadsideFirerate));
        canBroadside = true;
    }

    IEnumerator FrontalFireCooldown()
    {
        yield return new WaitForSeconds((2f / playerFrontalFirerrate));
        canFireFrontal = true;
    }


    public GameObject UpdateProjectileStats(Object projectile)
    {
        GameObject projectGameObject = projectile as GameObject;
        PlayerProjectile enemyProjectileStats = projectGameObject.GetComponent<PlayerProjectile>();

        enemyProjectileStats.projectileDamage = playerProjectileDamage;
        enemyProjectileStats.projectileSpeed = playerProjectileSpeed;

        return projectGameObject;
    }
}
