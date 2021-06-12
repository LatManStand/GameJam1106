using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sprite imageMuted;
    public Sprite imageNotMuted;

    public Image soundIcon;

    public Slider volumeSlider;

    private float volumeValue;

    public AudioSource normalButton;
    public AudioSource closeButton;


    void OnEnable(){

        SceneManager.sceneLoaded += RechargeScene;

    }

    void OnDisable(){

        SceneManager.sceneLoaded -= RechargeScene;

    }

    private void RechargeScene(Scene scene, LoadSceneMode mode){

        volumeSlider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = volumeSlider.value * volumeSlider.value;
        IsMuted();
    
    }


    public void ChangeVolumeSlider(float value)
    {

        volumeValue = value;
        PlayerPrefs.SetFloat("volumenAudio", volumeValue);
        AudioListener.volume = volumeSlider.value * volumeSlider.value;
        IsMuted();

    }

    private void IsMuted(){


        if(volumeValue == 0){

            soundIcon.sprite = imageMuted;

        }else{

            soundIcon.sprite = imageNotMuted;

        }


    }

    public void PlayNormalButtonSound(){

        Debug.Log("PAtata");
        normalButton.Play();
        

    }

    public void PlayCloseButtonSound()
    {

        closeButton.Play();

    }


}
