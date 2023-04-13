using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
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
}
