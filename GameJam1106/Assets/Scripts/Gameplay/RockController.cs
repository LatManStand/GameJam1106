using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockController : MonoBehaviour{


    public CalaveraController player;

    public TakeItemsController taker;

    public Sprite itemSprite;


    void Awake(){

        taker = FindObjectOfType<TakeItemsController>();

    }


    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

           
            taker.rock = GetComponent<RockController>();

            taker.playerInside = true;

            taker.actualItem = itemSprite;

        }


    }

    void OnTriggerExit2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

            taker.rock = null;

            taker.playerInside = false;

        }


    }

    

}
