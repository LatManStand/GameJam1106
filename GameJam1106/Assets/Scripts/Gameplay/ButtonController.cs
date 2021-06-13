using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour{

    public bool isOpen = false;

    public DoorController door;

    public Sprite buttonOn;
    public Sprite buttonOff;

    public AudioSource buttonSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item")){

            door.OpenDoor();
            GetComponent<SpriteRenderer>().sprite = buttonOn;
            buttonSound.Play();

        }
        

    }

    void OnTriggerExit2D(Collider2D collision){


        if (collision.CompareTag("Item")){


            door.CloseDoor();
            GetComponent<SpriteRenderer>().sprite = buttonOff;


        }



    }



}
