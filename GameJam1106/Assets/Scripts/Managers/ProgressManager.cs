using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {


    public bool[] levelsCompleted;
    


    public static ProgressManager instance;

    public int lastLevelCompleted;

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

        levelsCompleted = new bool[10];

        for(int i = 0; i < levelsCompleted.Length; i++){

            levelsCompleted[i] = false;

        }

        lastLevelCompleted = 0;

    }





}
