using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PesistenceCanvas : MonoBehaviour{

    public static PesistenceCanvas instance;

    private bool showingPausePanel = false;

    public int minIndex;

    public GameObject pauseMenuPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }


    }

   


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (SceneManager.GetActiveScene().buildIndex >= minIndex){
                OpenOptionsInGame();
            }

        }

    }

    private void OpenOptionsInGame(){

        if (!showingPausePanel)
        {

            pauseMenuPanel.SetActive(true);
            showingPausePanel = true;

            Time.timeScale = 0;

        }
        

    }

    public void RestartSecene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        pauseMenuPanel.SetActive(false);
        showingPausePanel = false;

        Time.timeScale = 1;

    }

    public void ResumeButton(){

        if(showingPausePanel){

            pauseMenuPanel.SetActive(false);
            showingPausePanel = false;

            Time.timeScale = 1;

        }



    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene("LevelSelector");

        if (showingPausePanel){

            pauseMenuPanel.SetActive(false);
            showingPausePanel = false;

            Time.timeScale = 1;

        }


    }



}
