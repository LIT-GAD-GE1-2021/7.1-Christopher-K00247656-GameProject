using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel(string name)
	{
		UnityEngine.Debug.Log("Load " + name + " Level");
		UnityEngine.SceneManagement.SceneManager.LoadScene(name);
	}

	public void QuitLevel(string name)
	{
		UnityEngine.Debug.Log("Quit the Application");
		Application.Quit();
	}
}
