using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool switchActive;
    public SpriteRenderer color;
    private Animation myAnimationComponent1;
    public GameObject door;
    private bool switchOnOff;


    void Start()
    {

    }

    void Update()
    {
        if (switchActive == true && switchOnOff == false)
        {   

            Color someColour;
            someColour = new Color(1, 0, 0);
            color.color = someColour;
            if (Input.GetKey(KeyCode.E) && switchOnOff == false)
            {

                myAnimationComponent1 = GetComponent<Animation>();
                myAnimationComponent1.Play("switchstatesOn"); ;
                switchOnOff = true;


                if (switchOnOff == true)
                {
                    someColour = new Color(1, 1, 1);
                    color.color = someColour;
                    Object.Destroy(door);

                }


            }

        }
        if (switchActive == false)
        {
            Color someColour;
            someColour = new Color(1, 1, 1);
            color.color = someColour;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switchActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switchActive = false;
        }
    }
}
