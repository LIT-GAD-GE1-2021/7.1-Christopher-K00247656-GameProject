using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sprite_Swap : MonoBehaviour
{

    public int spriteIndex;
    public List<Sprite> image = new List<Sprite>();
    void Start()
    {
        spriteIndex = 0;
        gameObject.GetComponent<Image>().sprite = image[spriteIndex];

    }

    void Update() {

        previousItem();
        nextItem();
    
    }

    public void previousItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && spriteIndex == 0)
        {
            spriteIndex = image.Count - 1;                
            gameObject.GetComponent<Image>().sprite = image[spriteIndex];
            Debug.Log(spriteIndex);              
        }
        if (Input.GetKeyDown(KeyCode.E) && spriteIndex <= image.Count - 1)
        {
            spriteIndex -= 1;            
            gameObject.GetComponent<Image>().sprite = image[spriteIndex];
            Debug.Log(spriteIndex);

           
        }
        

    }

    public void nextItem()
    {
        if (Input.GetKeyDown(KeyCode.Q) && spriteIndex < image.Count)
        {
            spriteIndex += 1;
            Debug.Log(spriteIndex);
            Debug.Log(image.Count);
            gameObject.GetComponent<Image>().sprite = image[spriteIndex];

        if (spriteIndex >= (image.Count) - 1)
            {
            spriteIndex = 0;
            gameObject.GetComponent<Image>().sprite = image[spriteIndex];
            Debug.Log(spriteIndex);
            }
        }
    }
}
