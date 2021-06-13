using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour
{

    public Button[] level;

    public ProgressManager progressManager;


    void Awake(){

        progressManager = FindObjectOfType<ProgressManager>();


    }

    void Start(){

        if(progressManager.lastLevelCompleted < 10){

            for (int i = 0; i < progressManager.lastLevelCompleted; i++)
            {

                level[i].interactable = true;

            }


        }else{
        
        
        
        }




    }

}