/*****************************************************************************
// File Name :         TestQuitBox.cs
// Author :            Jacob Lee
// Creation Date :     April 20th, 2023
//
// Allows players to go to main menu or level 1.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestQuitBox : MonoBehaviour
{
    /// <summary>
    /// Goes back to main menu if Level 1 and .
    /// </summary>
    public void SceneChange()
    {
        // If it's level 1, go to main menu. If it's Tutorial, go to Level 1.
        if (SceneManager.GetActiveScene().name == ("Level1"))
        {
            PlayerBehavior.hasPlayer1 = false;
            Debug.Log("Back");
            SceneManager.LoadScene("MainMenu");
        }
        else if (SceneManager.GetActiveScene().name == ("Tutorial"))
        {
            PlayerBehavior.hasPlayer1 = false;
            PlayerBehavior.isTutorial = false;
            SceneManager.LoadScene("Level1");
        }
    }

    /// <summary>
    /// On trigger, go back to main menu/level 1, depending on current scene.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneChange();
    }
}
