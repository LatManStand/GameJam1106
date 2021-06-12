using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{



    private bool showingPausePanel = false;


    public GameObject pauseMenuPanel;



    public static UIManager instance;

    void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        pauseMenuPanel = GameObject.FindGameObjectWithTag("Options");
        pauseMenuPanel.SetActive(false);
        showingPausePanel = false;

    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){

            OpenOptionsInGame();


        }

    }







    private void OpenOptionsInGame(){

        if (!showingPausePanel){
        
            pauseMenuPanel.SetActive(true);
            showingPausePanel = true;
        
        }else{

            pauseMenuPanel.SetActive(false);
            showingPausePanel = false;

        }
        

    }


}
