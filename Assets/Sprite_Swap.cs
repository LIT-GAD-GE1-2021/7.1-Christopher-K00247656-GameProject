using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Sprite_Swap : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public int spriteIndex;
    public List<Sprite> image = new List<Sprite>();
    void Start()
    {
        spriteIndex = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = image[spriteIndex];

    }



    public void previousItem()
    {
        if (spriteIndex == 0)
        {
            spriteIndex = image.Count - 1;                
            gameObject.GetComponent<SpriteRenderer>().sprite = image[spriteIndex];
            Debug.Log(spriteIndex);              
        }
        if (spriteIndex <= image.Count - 1)
        {
            spriteIndex -= 1;            
            gameObject.GetComponent<SpriteRenderer>().sprite = image[spriteIndex];
            Debug.Log(spriteIndex);

           
        }
        

    }

    public void nextItem()
    {
        if (spriteIndex < image.Count)
        {
            spriteIndex += 1;
            Debug.Log(spriteIndex);
            Debug.Log(image.Count);
            gameObject.GetComponent<SpriteRenderer>().sprite = image[spriteIndex];

        if (spriteIndex >= (image.Count) - 1)
            {
            spriteIndex = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = image[spriteIndex];
            Debug.Log(spriteIndex);
            }
        }
    }
}
