using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D controller;
    public float jumpForce;
    public float speed;
    public bool isGrounded;
    public Animator theAnimator;
    public Text health;
    public Text coins;
    public int healthNumber = 5;
    public int coinNumber;
    private int hitVelocity;
    public GameObject winCanvas;
    public GameObject UICanvas;
    public GameObject loseCanvas;


    void Start()
    {
        Time.timeScale = 1;
        health.text = "" + healthNumber;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundPlatform")
        {
            isGrounded = true;
            Debug.Log(isGrounded);
            theAnimator.SetBool("jump", false);
        }


        if (collision.gameObject.tag == "Enemy")
        {

            healthNumber -= 1;
            health.text = "" + healthNumber;
            controller.velocity = Vector2.up * 10;
            controller.velocity = Vector2.left * 10;
        }
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            coinNumber += 1;

        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundPlatform")
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }

    void Update()
    {
        coins.text = "x" + coinNumber;
        moveRightandLeft();
        moveUp();
        win();
        death();
    }
    void moveRightandLeft()
    {
        if (Input.GetKey("d") && isGrounded == true)
        {
            controller.velocity = Vector2.right * speed;
            theAnimator.SetFloat("Walking Speed", speed);
            Quaternion theRotation = transform.localRotation;
            theRotation.y = 0;
            transform.localRotation = theRotation;
            if (Input.GetKey("d") && Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
            {
                controller.velocity = Vector2.right * speed * 2;
                theAnimator.SetFloat("Walking Speed", speed);


            }
        }


        else if (Input.GetKey("a") && isGrounded == true)
        {
            controller.velocity = Vector2.left * speed;
            theAnimator.SetFloat("Walking Speed", speed);
            Quaternion theRotation = transform.localRotation;
            theRotation.y = 180;
            transform.localRotation = theRotation;

            if (Input.GetKey("a") && Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
            {
                controller.velocity = Vector2.left * speed * 2;
                theAnimator.SetFloat("Walking Speed", speed);


            }
        }


        else if (isGrounded)
        {
            controller.velocity = new Vector2(0, controller.velocity.y);
            theAnimator.SetFloat("Walking Speed", 0);
        }
    }


    void moveUp()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            controller.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            theAnimator.SetBool("jump", true);
        }
    }

    void win()
    {
        if (coinNumber >= 3)
        {
            Time.timeScale = 0;

            UICanvas.SetActive(false);
            winCanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R) == true)
            {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

            }

        }
    }
    void death()
    {
        if (healthNumber <= 0)
        {
            UICanvas.SetActive(false);
            loseCanvas.SetActive(true);
        }
    }
}

