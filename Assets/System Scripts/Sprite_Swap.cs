using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Swap : MonoBehaviour
{
    public List<Sprite> image = new List<Sprite>();



    void Update()
    {
        previousItem();
        nextItem();
    }

    public void previousItem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameManager.instance.spriteIndex == 0)
            {
                GameManager.instance.spriteIndex = image.Count - 1;
                gameObject.GetComponent<Image>().sprite = image[GameManager.instance.spriteIndex];
                Debug.Log(GameManager.instance.spriteIndex);
            }
            if (GameManager.instance.spriteIndex <= image.Count - 1)
            {
                GameManager.instance.spriteIndex -= 1;
                gameObject.GetComponent<Image>().sprite = image[GameManager.instance.spriteIndex];
                Debug.Log(GameManager.instance.spriteIndex);


            }
        }

    }

    public void nextItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (GameManager.instance.spriteIndex < image.Count)
            {
                GameManager.instance.spriteIndex += 1;
                Debug.Log(GameManager.instance.spriteIndex);
                Debug.Log(image.Count);
                gameObject.GetComponent<Image>().sprite = image[GameManager.instance.spriteIndex];

                if (GameManager.instance.spriteIndex >= (image.Count) - 1)
                {
                    GameManager.instance.spriteIndex = 0;
                    gameObject.GetComponent<Image>().sprite = image[GameManager.instance.spriteIndex];
                    Debug.Log(GameManager.instance.spriteIndex);
                }
            }
        }
    }
}
