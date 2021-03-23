using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class Timer : MonoBehaviour
{

    public float timeRemaining = 10;
    private bool timerRunning;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                timer.text = "" + timeRemaining;
            }
            else
            {
                Debug.Log("Time has run out");
                timeRemaining = 0;
                timerRunning = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over");
            }
        }
    }
}
