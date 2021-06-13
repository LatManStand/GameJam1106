using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItemsController : MonoBehaviour{

    public CalaveraController player;
    public ItemController item;

    private GameObject holdingItem;

    public bool playerInside = false;

    public bool haveItem = false;

    public Image itemImage;

    public Sprite actualItem;

    public Sprite emptyItemSprite;

    public AudioSource biteSound;

    void Update(){

        if (Input.GetKeyDown(KeyCode.E)){

            if (playerInside && !haveItem){

                TakeItem();

            }else if (haveItem){

                DropItem();

            }
            

        }

    }

    private void TakeItem(){

        biteSound.Play();
        holdingItem = item.gameObject;
        item.gameObject.SetActive(false);
        itemImage.sprite = actualItem;
        playerInside = false;
        haveItem = true;

    }


    private void DropItem(){

        holdingItem.transform.position = player.transform.position;
        holdingItem.SetActive(true);
        itemImage.sprite = emptyItemSprite; 
        playerInside = true;
        haveItem = false;
        holdingItem = null;

    }




}
