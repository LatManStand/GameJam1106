using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour
{

    public Button[] level;

    public ProgressManager progressManager;

    public GameObject gameCompletedImage;

    void Awake(){

        progressManager = FindObjectOfType<ProgressManager>();


    }

    void Start(){

        if(progressManager.lastLevelCompleted < 6){

            for (int i = 0; i < progressManager.lastLevelCompleted; i++)
            {

                level[i].interactable = true;

            }


        }else{

            gameCompletedImage.SetActive(true);

            for (int i = 0; i < progressManager.lastLevelCompleted; i++)
            {

                level[i].interactable = true;

            }

        }




    }

}
