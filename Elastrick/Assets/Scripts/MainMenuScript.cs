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
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// when Level 1 Button clicked, loads the Game Level
    /// </summary>
    public void StartLevel01()
    {
        Debug.Log("Start Level01");
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// when Quit Button clicked, the application should close
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

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

    void Start()
    {
        MenuNavigation();
    }
}
