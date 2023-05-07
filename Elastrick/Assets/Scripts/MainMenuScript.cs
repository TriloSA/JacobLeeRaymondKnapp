/*****************************************************************************
// File Name :         MainMenuScript.cs
// Author :            Raymond Knapp
// Creation Date :     May 7th, 2023
//
// This script for the main menu holds functions for the buttons located in the 
// main menu scene. the code written below holds a few functions. The Main function
// at this time is starting the level scene, held in the StartLevelOne function. 
// The other code in this script is used to help a controller interact with the 
// buttons in the scene.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{
    //this allows the code to recognize when the Main Menu, Level Menu, or HTPMenu
    //are active, or inactive
    public GameObject mainMenu;
    public GameObject controlsMenu;
    public GameObject htpMenu;

    //this allows the code to recognize which button gets highlighted when any 
    //of the menus are active or inactive
    public GameObject playButton;
    public GameObject controlsBackButton;
    public GameObject powerupsBackButton;
    public GameObject obstaclesBackButton;
    public GameObject HTPBackButton;
    public GameObject controlsButton;

    /// <summary>
    ///  When Tutorial Button is clicked, loads the Tutorial Level
    /// </summary>
    public void StartTutorial()
    {
        Debug.Log("Start Tutorial");
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// when Level 1 Button clicked, loads the Game Level
    /// </summary>
    public void StartLevel01()
    {
        Debug.Log("Start Level01");
        SceneManager.LoadScene("Level1");
    }

    /// <summary>
    /// when Quit Button clicked, the application should close
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    /// <summary>
    /// this function sets the selected gameObject in the HowToPay to the controlsButton
    /// </summary>
    public void ControlsOff()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the ControlsMenu to the backButton
    /// </summary>
    public void ControlsOn()
    {
        EventSystem.current.SetSelectedGameObject(controlsBackButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the HowToPlayMenu to the controlsButton
    /// </summary>
    public void HowToPlayOn()
    {
        EventSystem.current.SetSelectedGameObject(controlsButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the MainMenu to the playButton
    /// </summary>
    public void HowToPlayOff()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the PowerUpMenu to the 
    /// backButton associated with the PowerUpMenu
    /// </summary>
    public void PowerUpsOn()
    {
        EventSystem.current.SetSelectedGameObject(powerupsBackButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the HowToPlayMenu to the controlsButton
    /// </summary>
    public void PowerUpsOff()
    {
        EventSystem.current.SetSelectedGameObject(controlsButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the ObstaclesMenu to the 
    /// backButton associated with the ObstaclesMenu
    /// </summary>
    public void ObstaclesOn()
    {
        EventSystem.current.SetSelectedGameObject(obstaclesBackButton);
    }

    /// <summary>
    /// this function sets the selected gameObject in the HowToPlayMenu to the controlsButton
    /// </summary>
    public void ObstaclesOff()
    {
        EventSystem.current.SetSelectedGameObject(controlsButton);
    }

    /// <summary>
    /// the start function calls the MenuNavigation code, which is explained above,
    /// the start function tells the called function inside to execute the code
    /// that the called function has
    /// </summary>
    void Start()
    {
        // Jacob: Resets the time scale if it was set to 0 from Level 1.
        Time.timeScale = 1;

        ControlsOff();
    }
}
