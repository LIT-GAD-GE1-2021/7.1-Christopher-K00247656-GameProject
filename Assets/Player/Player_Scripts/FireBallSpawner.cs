using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBall;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(fireBall, firePoint.position, firePoint.rotation);
        }
    }


}
