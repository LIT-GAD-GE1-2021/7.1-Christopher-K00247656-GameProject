using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spawnpoints : MonoBehaviour
{
    public GameObject enemysimple;
    public Transform spawnpoint1;
    GameObject[] gameObjects;





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            GameObject EnemySimple;
            EnemySimple = Instantiate(enemysimple, spawnpoint1.position, Quaternion.identity);


            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("enemies!" + gameObjects.Length);
        }

    }

    }

