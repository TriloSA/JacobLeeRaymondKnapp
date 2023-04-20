/*****************************************************************************
// File Name :         AlphaQuitBox.cs
// Author :            Jacob Lee
// Creation Date :     April 20th, 2023
//
// For alpha, but allows players to quit in game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphaQuitBox : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Debug.Log("Back");
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BackToMainMenu();
    }
}
