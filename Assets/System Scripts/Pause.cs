using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject CanvasObject;
    public GameObject UICanvas;
    private bool pause = false;

    void Start()
    {
        CanvasObject.SetActive(false);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && pause == false)
        {
            Time.timeScale = 0;

                CanvasObject.SetActive(true);
                UICanvas.SetActive(false);

            pause = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.P) && pause == true)
        {
            Time.timeScale = 1;

            CanvasObject.SetActive(false);
            UICanvas.SetActive(true);
            pause = false;

        }

    }
}
