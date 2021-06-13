using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItemsController : MonoBehaviour{

    public CalaveraController player;
    public RockController rock;

    private GameObject holdingItem;

    public bool playerInside = false;

    public bool haveItem = false;

    public Image itemImage;

    public Sprite actualItem;

    public Sprite emptyItemSprite;

    void Update(){

        if (Input.GetKeyDown(KeyCode.E)){

            if (playerInside && !haveItem){

                TakeRock();

            }else if (haveItem){

                DropRock();

            }
            

        }

    }

    public void GetItemInfo(){



    }


    private void TakeRock(){

        holdingItem = rock.gameObject;
        rock.gameObject.SetActive(false);
        itemImage.sprite = actualItem;
        playerInside = false;
        haveItem = true;

    }


    private void DropRock(){

        holdingItem.transform.position = player.transform.position;
        holdingItem.SetActive(true);
        itemImage.sprite = emptyItemSprite; 
        playerInside = true;
        haveItem = false;
        holdingItem = null;

    }




}
