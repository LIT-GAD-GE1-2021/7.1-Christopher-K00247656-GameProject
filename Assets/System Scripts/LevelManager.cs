using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour

{
	public static LevelManager instance;

    public GameObject PauseMenu;
    public GameObject UI;
    private bool pause = false;
    public int spriteIndex;
    public List<AudioClip> audioclips = new List<AudioClip>();

    void Start()
    {
        UI.SetActive(true);
        PauseMenu.SetActive(false);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && pause == false)
        {
            Time.timeScale = 0;

            PauseMenu.SetActive(true);
            UI.SetActive(false);

            pause = true;

        }
        else if (Input.GetKeyDown(KeyCode.P) && pause == true)
        {
            Time.timeScale = 1;

            PauseMenu.SetActive(false);
            UI.SetActive(true);
            pause = false;

        }

    }

    public void LoadLevel(string name)
	{
		UnityEngine.Debug.Log("Load " + name + " Level");
		UnityEngine.SceneManagement.SceneManager.LoadScene(name);
	}

	public void restartCurrentScene()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void QuitLevel(string name)
	{
		UnityEngine.Debug.Log("Quit the Application");
		Application.Quit();
	}
}
