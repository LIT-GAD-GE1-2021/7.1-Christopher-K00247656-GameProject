using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public void LoadLevel(string name)
    {
        Debug.Log("Load " + name + " Level");
        SceneManager.LoadScene(name);
    }
    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void SoundFXs(AudioClip name)
    {
        GetComponent<AudioSource>().PlayOneShot(name, 1f);
    }
}