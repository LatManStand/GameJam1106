using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelController : MonoBehaviour{


    private ProgressManager progressManager;

    public int currentLevel;

    public GameObject levelCompletedPanel;

    void Awake(){

        progressManager = FindObjectOfType<ProgressManager>();

    }


    void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Cabeza") || collision.CompareTag("Cuerpo"))
        {

            if (!(progressManager.levelsCompleted[currentLevel-1])){

                progressManager.lastLevelCompleted = currentLevel;
                progressManager.levelsCompleted[currentLevel-1] = true;

            }

            levelCompletedPanel.SetActive(true);

            Time.timeScale = 0;

        }

    }





}
