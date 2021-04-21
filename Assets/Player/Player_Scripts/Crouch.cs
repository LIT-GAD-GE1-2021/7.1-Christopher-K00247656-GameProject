using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crouch : MonoBehaviour
{
    SpriteRenderer sprite;
    public AudioSource audioclip;
    public AudioClip rustle;
    private bool isPlayed;

    void Awake()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.instance.isHiding == true)
        {
            hide();
        }
    }

    void hide()
    {
        if (Input.GetKey("s"))
        {
            Debug.Log("Is Crouched");
            sprite.sortingOrder = -3;
            sprite.color = new Color32(123, 123, 123,255);
            Debug.Log(sprite.color);

            if (isPlayed == false) {
                audioclip.PlayOneShot(rustle, 1f);
                isPlayed = true;
            }

        }
        else
        {
            isPlayed = false;
            sprite.color = new Color32(255, 255, 255, 255);
            Debug.Log(sprite.color);
            sprite.sortingOrder = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HideSpot")
        {
            GameManager.instance.isHiding = true;   
            Debug.Log(GameManager.instance.isHiding);

            
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HideSpot")
        {
            GameManager.instance.isHiding = false;            
            Debug.Log(GameManager.instance.isHiding);
            sprite.color = new Color32(255, 255, 255, 255);
            Debug.Log(sprite.color);
            sprite.sortingOrder = 0;


        }

    }

}
