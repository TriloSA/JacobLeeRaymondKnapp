/*****************************************************************************
// File Name :         MainMenuScript.cs
// Author :            Raymond Knapp
// Creation Date :     April 13th, 2023
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
    //this allows the code to recognize when the Main Menu and the Level Menu
    //are active, or inactive
    public GameObject mainMenu;
    public GameObject levelMenu;

    //this allows the code to recognize which button gets highlighted when the 
    //Main Menu or Level Menu is active or inactive
    public GameObject playButton;
    public GameObject tutorialButton;

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
    /// this function does not matter with the current state of the project
    /// this function will be used to help the controller recognize which button 
    /// to highlight once we add more layers to the main menu
    /// (for example, an options menu and credits menu)
    /// </summary>
    public void MenuNavigation()
    {
        if (!mainMenu.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(tutorialButton);
        }
        else if (mainMenu.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(playButton);
        }
    }

    /// <summary>
    /// the start function calls the MenuNavigation code, which is explained above,
    /// the start function tells the called function inside to execute the code
    /// that the called function has
    /// </summary>
    void Start()
    {
        MenuNavigation();
    }
}
