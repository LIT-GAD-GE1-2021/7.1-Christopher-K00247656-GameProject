using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject noNote;
    public GameObject noKey;
    public GameObject enter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GameManager.instance.hasNote == false)
            {
                noNote.SetActive(true);
            }
            if (GameManager.instance.hasKey == false)
            {
                noKey.SetActive(true);
            }
            if (GameManager.instance.hasNote == true && GameManager.instance.hasKey == true)
            {
                enter.SetActive(true);
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            noNote.SetActive(false);
            noKey.SetActive(false);
            enter.SetActive(false);
        }

    }
    }


