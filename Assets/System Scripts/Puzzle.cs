using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Puzzle : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GameManager.instance.hasNote == false)
            {
                GameManager.instance.notePrompt.SetActive(true);
            }
            if (GameManager.instance.hasKey == false)
            {
                GameManager.instance.keyPrompt.SetActive(true);
            }
            if (GameManager.instance.hasNote == true && GameManager.instance.hasKey == true)
            {
                GameManager.instance.enter.SetActive(true);
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.notePrompt.SetActive(false);
            GameManager.instance.keyPrompt.SetActive(false);
            GameManager.instance.enter.SetActive(false);
        }

    }
    }


