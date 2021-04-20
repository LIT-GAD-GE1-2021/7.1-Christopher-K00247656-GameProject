using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.UI.SetActive(false);
            GameManager.instance.loseMenu.SetActive(true);
            destroyPlayer();
        }
        else
        {
            Destroy(collision.gameObject);
        }
       
    }

    private IEnumerator destroyPlayer()
        {
            while (true)
            {
            yield return new WaitForSeconds(4);
            Destroy(GameObject.FindWithTag("Player"));
        }
        }
}
