using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    private bool showingOptionsPanel = false;

    public GameObject optionsPanel;

    public void ShowOptionsPanel()
    {

        if (showingOptionsPanel)
        {

            optionsPanel.SetActive(false);
            showingOptionsPanel = false;

        }
        else
        {

            optionsPanel.SetActive(true);
            showingOptionsPanel = true;

        }


    }





    public void ExitGame()
    {

        Application.Quit();

    }







}
