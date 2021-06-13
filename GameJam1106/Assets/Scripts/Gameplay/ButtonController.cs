using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour{

    public bool isOpen = false;

    public DoorController door;

    public Sprite buttonOn;
    public Sprite buttonOff;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock")){

            door.OpenDoor();
            GetComponent<SpriteRenderer>().sprite = buttonOn;

        }
        

    }

    void OnTriggerExit2D(Collider2D collision){


        if (collision.CompareTag("Rock")){


            door.CloseDoor();
            GetComponent<SpriteRenderer>().sprite = buttonOff;


        }



    }



}
