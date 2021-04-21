using System.Collections;
using System.Configuration;
using System.Security.Cryptography;
using UnityEngine;

public class enemyAI : MonoBehaviour
{

    Rigidbody2D enemy;
    public GameObject player;
    public float walkSpeed;
    public Transform PatrolRay;
    public Transform AttackRay;
    public int health;
    public float viewDistance;
    public float FOV;   
    public AudioClip growl;
    public float AudioVolume;
    private bool isPlayed;
    private bool isAttacking;
    private bool movingRight = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health -= 1;
        }
    }
    void Start()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        enemy = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        if (movingRight == true)
        {
            enemy.velocity = Vector2.right * walkSpeed * Time.deltaTime;
        }
        else
        {
            enemy.velocity = Vector2.left * walkSpeed * Time.deltaTime;
        }
        if(isAttacking == true)
        {
            Attacking();
        }

        Vector2 PatrolDirection = transform.TransformDirection(Vector2.right) * viewDistance;
        Vector2 attackDirection = transform.TransformDirection(Vector2.right) * FOV;

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D rayHit = Physics2D.Raycast(PatrolRay.position, PatrolDirection , viewDistance);
        RaycastHit2D attackView = Physics2D.Raycast(AttackRay.position, attackDirection, FOV);

        Debug.DrawRay(PatrolRay.position, PatrolDirection, Color.green);
        Debug.DrawRay(AttackRay.position, attackDirection, Color.red);

        if (rayHit.collider != null)
        {

            if (rayHit.collider.tag == "GroundPlatform" || rayHit.collider.tag == "Patrol Bounds")
            {
                Patrol();
            }
        }
        if (attackView.collider != null)
        {

            if (attackView.collider.tag == "Player")
            {
                if (GameManager.instance.isHiding == true)
                {
                    Physics2D.IgnoreLayerCollision(9,8, true);
                }
                else
                {
                    isAttacking = true;
                }
            }
            else
            {
                walkSpeed = 40f;
                isAttacking = false;
                isPlayed = false;
            }

        }


        Death();

    }

    void Attacking()
    {

        walkSpeed = 100f;
        if(isPlayed == false)
        {
        GetComponent<AudioSource>().PlayOneShot( growl, AudioVolume);
            isPlayed = true;
        }
    }

    void Patrol()
    {
        if (movingRight == true)
        {
            Quaternion theRotation = transform.localRotation;
            theRotation.y = 180;
            transform.localRotation = theRotation;
            movingRight = false;
            Debug.Log("Collided");
        }
        else
        {
            Quaternion theRotation = transform.localRotation;
            theRotation.y = 0;
            transform.localRotation = theRotation;
            movingRight = true;
            Debug.Log("Collided");
        }

    }
    void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}



