using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform player; 

    void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = pos;
        
    }
}
