using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour{

    public Collider2D collider;

    public Sprite openedDoor;
    public Sprite closedDoor;


    public void OpenDoor(){

        collider.enabled = false;

        GetComponent<SpriteRenderer>().sprite = openedDoor;

        
    }


    public void CloseDoor()
    {

        collider.enabled = true;

        GetComponent<SpriteRenderer>().sprite = closedDoor;


    }


}
