using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour{


    public CalaveraController player;

    public TakeItemsController taker;

    public Sprite itemSprite;

    public GameObject E;


    void Awake(){

        taker = FindObjectOfType<TakeItemsController>();

    }


    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

            Debug.Log("entra");
            
            taker.item = GetComponent<ItemController>();

            taker.playerInside = true;

            taker.actualItem = itemSprite;

            E.SetActive(true);

        }


    }

    void OnTriggerExit2D(Collider2D collision){

        if (collision.CompareTag("Cabeza")){

            taker.item = null;

            taker.playerInside = false;

            E.SetActive(false);

        }


    }

    

}
