/*****************************************************************************
// File Name :         WinAndSceneBehavior.cs
// Author :            Jacob Lee
// Creation Date :     April 20th, 2023
//
// Allows players to go to main menu or level 1. Also displays who won if
// on Level 1.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndSceneBehavior : MonoBehaviour
{
    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject winTextBackground;
    public GameObject music;
    public AudioClip gameEndSound;

    /// <summary>
    /// Goes back to main menu if Level 1 and if it's the Tutorial, to Level1.
    /// </summary>
    public void SceneChange()
    {
        // If it's level 1, go to main menu as well as if it's Tutorial.
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
            SceneManager.LoadScene("MainMenu");
        }
    }

    /// <summary>
    /// On trigger, go back to main menu/level 1, depending on current scene.
    /// If its Level 1, pause the game and say that a player won. Does the
    /// whole win process with UI and SFX if its on Level 1 going to main menu.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If you hit the Level1 version, play the win process...
        if (SceneManager.GetActiveScene().name == ("Level1"))
        {
            // If you are player 1, say that player 1 won.
            if (collision.gameObject.GetComponent<PlayerBehavior>().isPlayer1)
            {
                Time.timeScale = 0;
                winTextBackground.SetActive(true);
                p1Wins.SetActive(true);
                music.SetActive(false);
                AudioManager.inst.PlaySound(gameEndSound);
                StartCoroutine(WaitToReturnToMainMenu());
            }
            // If you are not player 1, say that player 2 won.
            if (!collision.gameObject.GetComponent<PlayerBehavior>().isPlayer1)
            {
                Time.timeScale = 0;
                winTextBackground.SetActive(true);
                p2Wins.SetActive(true);
                music.SetActive(false);
                AudioManager.inst.PlaySound(gameEndSound);
                StartCoroutine(WaitToReturnToMainMenu());
            }
        }

        // If it's the tutorial version you're hitting, just simply change
        // scenes. Ignore the win process. No need to utilize all of those
        // game objects.
        else if (SceneManager.GetActiveScene().name == ("Tutorial"))
        {
            SceneChange();
        }
    }

    /// <summary>
    /// Adds in artificial wait time for players to witness who won.
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitToReturnToMainMenu()
    {
        // Might not work due to the Time.timeScale above.
        yield return new WaitForSecondsRealtime(3.5f);
        p1Wins.SetActive(false);
        p2Wins.SetActive(false);
        winTextBackground.SetActive(false);
        SceneChange();
    }
}
