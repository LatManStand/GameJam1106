using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Image imageMuted;
    public Image imageNotMuted;
    
    public Slider volumeSlider;
    

    private float volumeValue;
    

    void Start(){

        volumeSlider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = volumeSlider.value * volumeSlider.value;
        //IsMuted();
    
    }


    public void ChangeVolumeSlider(float value)
    {

        volumeValue = value;
        PlayerPrefs.SetFloat("volumenAudio", volumeValue);
        AudioListener.volume = volumeSlider.value * volumeSlider.value;
        //IsMuted();

    }

    private void IsMuted(){


        if(volumeValue == 0){

            imageMuted.enabled = true;
            imageNotMuted.enabled = false;

        }else{

            imageMuted.enabled = false;
            imageNotMuted.enabled = true;

        }


    }


}
