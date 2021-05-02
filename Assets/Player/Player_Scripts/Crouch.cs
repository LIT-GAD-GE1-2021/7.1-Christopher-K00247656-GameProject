using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crouch : MonoBehaviour
{
    SpriteRenderer sprite;
    public AudioSource audioclip;
    public GameObject hidePrompt;
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
            sprite.sortingOrder = -3;
            sprite.color = new Color32(123, 123, 123,255);
            hidePrompt.SetActive(false);

            if (isPlayed == false) {
                audioclip.PlayOneShot(rustle, 1f);
                isPlayed = true;
            }

        }
        else
        {
            isPlayed = false;
            sprite.color = new Color32(255, 255, 255, 255);
            sprite.sortingOrder = 0;
            hidePrompt.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HideSpot")
        {
            GameManager.instance.isHiding = true;
            hidePrompt.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HideSpot")
        {
            GameManager.instance.isHiding = false;
            hidePrompt.SetActive(false);
            sprite.color = new Color32(255, 255, 255, 255);
            sprite.sortingOrder = 0;


        }

    }

}
