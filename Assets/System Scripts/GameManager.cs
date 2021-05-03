using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;

    public GameObject loseMenu;
    public GameObject PauseMenu;
    public GameObject TitleScreen;
    public GameObject notePrompt;
    public GameObject keyPrompt;
    public GameObject enter;
    public GameObject Note;
    public GameObject S;
    public bool hasKey;
    public bool hasNote;
    public Text health;
    public Text coins;
    [HideInInspector] public int healthNumber = 5;
    [HideInInspector] public int coinNumber;
    public GameObject UI;
    private bool pause = false;
    [HideInInspector] public int spriteIndex;
    [HideInInspector] public bool isHiding;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            UI.SetActive(true);
            TitleScreen.SetActive(false);
        }

        else
        {
            PauseMenu.SetActive(false);
            loseMenu.SetActive(false);
            UI.SetActive(false);
            TitleScreen.SetActive(true);
        }
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
        if(hasNote == true)
        {
            Note.SetActive(true);
        }
        else
        {
            Note.SetActive(false);
        }

    }

    public void LoadLevel(string name)
    {

        StartCoroutine(Load(name));

    }
    private IEnumerator Load(string name)
    {
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("Load " + name + " Level");
        SceneManager.LoadScene(name);

        if (name == "Main Menu")
        {
            PauseMenu.SetActive(false);
            loseMenu.SetActive(false);
            UI.SetActive(false);
            TitleScreen.SetActive(true);
            enter.SetActive(false);
            hasNote = false;
        }
        else
        {
            PauseMenu.SetActive(false);
            loseMenu.SetActive(false);
            UI.SetActive(true);
            TitleScreen.SetActive(false);
            enter.SetActive(false);
            coinNumber = 0;
            healthNumber = 5;
            Note.SetActive(false);
            hasNote = false;
        }
    }

    public void restartCurrentScene()
    {
        StartCoroutine(reload());
    }
    private IEnumerator reload()
    {
        yield return new WaitForSecondsRealtime(1);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        PauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        hasNote = false;
        coinNumber = 0;
        healthNumber = 5;
    }


    public void QuitLevel(string name)
    {
        Debug.Log("Quit the Application");
        Application.Quit();
    }
    public void SoundFXs(AudioClip name)
    {
        GetComponent<AudioSource>().PlayOneShot(name, 1f);
    }
}
