using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour{


    public CalaveraController player;

    public TakeItemsController taker;

    public Sprite itemSprite;


    void Awake(){

        taker = FindObjectOfType<TakeItemsController>();

    }


    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

            Debug.Log("entra");
            
            taker.item = GetComponent<ItemController>();

            taker.playerInside = true;

            taker.actualItem = itemSprite;

            GetComponent<SpriteRenderer>().color = Color.yellow;

        }


    }

    void OnTriggerExit2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

            taker.item = null;

            taker.playerInside = false;

            GetComponent<SpriteRenderer>().color = Color.white;

        }


    }

    

}
