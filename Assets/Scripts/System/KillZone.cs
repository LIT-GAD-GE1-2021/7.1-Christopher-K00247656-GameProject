using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject loseCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UICanvas.SetActive(false);
            loseCanvas.SetActive(true);
        }
        else
        {
            Destroy(collision.gameObject);
        }

    }
}
