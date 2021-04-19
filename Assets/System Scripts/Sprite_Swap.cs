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
            if (LevelManager.instance.spriteIndex == 0)
            {
                LevelManager.instance.spriteIndex = image.Count - 1;
                gameObject.GetComponent<Image>().sprite = image[LevelManager.instance.spriteIndex];
                Debug.Log(LevelManager.instance.spriteIndex);
            }
            if (LevelManager.instance.spriteIndex <= image.Count - 1)
            {
                LevelManager.instance.spriteIndex -= 1;
                gameObject.GetComponent<Image>().sprite = image[LevelManager.instance.spriteIndex];
                Debug.Log(LevelManager.instance.spriteIndex);


            }
        }

    }

    public void nextItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (LevelManager.instance.spriteIndex < image.Count)
            {
                LevelManager.instance.spriteIndex += 1;
                Debug.Log(LevelManager.instance.spriteIndex);
                Debug.Log(image.Count);
                gameObject.GetComponent<Image>().sprite = image[LevelManager.instance.spriteIndex];

                if (LevelManager.instance.spriteIndex >= (image.Count) - 1)
                {
                    LevelManager.instance.spriteIndex = 0;
                    gameObject.GetComponent<Image>().sprite = image[LevelManager.instance.spriteIndex];
                    Debug.Log(LevelManager.instance.spriteIndex);
                }
            }
        }
    }
}
