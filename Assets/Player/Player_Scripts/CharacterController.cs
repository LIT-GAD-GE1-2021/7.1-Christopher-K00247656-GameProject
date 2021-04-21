using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{

    Rigidbody2D controller;
    Animator theAnimator;
    SpriteRenderer sprite;
    public float jumpForce;
    public float speed;
    private bool isGrounded;   
    private int hitVelocity;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;

    void Awake()
    {
        controller = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Time.timeScale = 1;
        GameManager.instance.health.text = "" + GameManager.instance.healthNumber;
        GameManager.instance.UI.SetActive(true);
        GameManager.instance.loseMenu.SetActive(false);

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

            GameManager.instance.healthNumber -= 1;
            GameManager.instance.health.text = "" + GameManager.instance.healthNumber;
            controller.velocity = Vector2.up * 10;
            controller.velocity = Vector2.left * 10;
        }
        if (collision.gameObject.tag == "Collectable")
        {
            GameManager.instance.coinNumber += 1;
            
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
            GameManager.instance.coins.text = "x" + GameManager.instance.coinNumber;
            moveRightandLeft();
            moveUp();
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
        if (controller.velocity.y < 0)
        {
            controller.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (controller.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            controller.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            controller.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            theAnimator.SetBool("jump", true);
        }
    }
    void death()
    {
        if (GameManager.instance.healthNumber <= 0)
        {
            GameManager.instance.UI.SetActive(false);
            GameManager.instance.loseMenu.SetActive(true);
        }
    }
}

