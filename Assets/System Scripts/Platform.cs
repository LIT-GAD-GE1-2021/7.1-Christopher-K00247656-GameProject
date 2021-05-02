using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;
    public Transform platform;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        // Sets "newParent" as the new parent of the child GameObject.
        //player.transform.SetParent(platform);

        // Same as above, except worldPositionStays set to false
        // makes the child keep its local orientation rather than
        // its global orientation.
        player.transform.SetParent(platform, true);
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.transform.SetParent(null);

    }
}
