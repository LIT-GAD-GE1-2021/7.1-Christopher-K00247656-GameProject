using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    AudioSource KeyFXs;
    private float wait = .1f;
    void Start()
    {
        KeyFXs = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(waitFor());
            
        }
    }

    private IEnumerator waitFor()
    {
        while (true)
        {
            KeyFXs.Play();
            yield return new WaitForSeconds(wait);
            Destroy(gameObject);
        }
    }
}