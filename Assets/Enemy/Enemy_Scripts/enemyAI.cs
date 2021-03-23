using System.Collections;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float walkSpeed = 20f;
    public Rigidbody2D enemy;
    public Animator theAnimation;
    private bool movingRight = true;
    public int health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Patrol Bounds")
        {
            if (movingRight == true)
            {
                Quaternion theRotation = transform.localRotation;
                theRotation.y = 180;
                transform.localRotation = theRotation;
                movingRight = false;
                theAnimation.SetBool("walking", true);
                Debug.Log("Collided");
            }
            else
            {
                Quaternion theRotation = transform.localRotation;
                theRotation.y = 0;
                transform.localRotation = theRotation;
                movingRight = true;
                theAnimation.SetBool("walking", true);
                Debug.Log("Collided");
            }
            

        }
        if (collision.gameObject.tag == "Projectile")
        {
            health -= 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

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
        Death();
    }
    void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
