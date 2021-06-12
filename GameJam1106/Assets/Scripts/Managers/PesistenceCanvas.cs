using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PesistenceCanvas : MonoBehaviour{

    public static PesistenceCanvas instance;

    public Slider volumeSlider;
    private float volumeValue;

    

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

    void Start(){

        volumeSlider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = volumeSlider.value * volumeSlider.value;

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
        else
        {

            pauseMenuPanel.SetActive(false);
            showingPausePanel = false;

            Time.timeScale = 1;

        }


    }

    public void RestartSecene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        pauseMenuPanel.SetActive(false);
        showingPausePanel = false;

        Time.timeScale = 1;

    }

    public void ChangeVolumeSlider(float value){

        volumeValue = value;
        PlayerPrefs.SetFloat("volumenAudio", volumeValue);
        AudioListener.volume = volumeSlider.value * volumeSlider.value;
        
    }

}
