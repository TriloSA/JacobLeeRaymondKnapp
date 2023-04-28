/*****************************************************************************
// File Name :         TestQuitBox.cs
// Author :            Jacob Lee
// Creation Date :     April 20th, 2023
//
// For alpha, but allows players to quit in game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestQuitBox : MonoBehaviour
{
    /// <summary>
    /// Goes back to main menu.
    /// </summary>
    public void BackToMainMenu()
    {
        PlayerBehavior.hasPlayer1 = false;
        Debug.Log("Back");
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// On trigger, go back to main menu.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BackToMainMenu();
    }
}
