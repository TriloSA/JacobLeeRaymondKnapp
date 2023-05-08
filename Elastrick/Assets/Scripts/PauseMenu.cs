/*****************************************************************************
// File Name :         PauseMenu.cs
// Author :            Jacob Lee
// Creation Date :     May 7th, 2023
//
// The primary script for PauseMenu which is also used and referenced in the
PlayerMovement script. Adds in a UI overlay to the game and pauses the world's
time stat to allow players to return to game or main menu.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause")]
    public GameObject pauseMenuObject;

    [Header("Action Stuff")]
    PlayerActions pActions;
    InputActionAsset pActionInput;

    [Header("Linkage")]
    PowerupManager pUM;
    InputActionMap pAM;
    WinAndSceneBehavior wASB;
    PlayerMovement pM;

    [Header("UI")]
    public GameObject returnToMainMenuButton;
    public GameObject powerup1;
    public GameObject powerup2;

    /// <summary>
    /// Removes any accidental going back to main menu.
    /// </summary>
    private void Start()
    {
        returnToMainMenuButton.SetActive(false);
        pauseMenuObject.transform.position = new Vector3(-999,
            pauseMenuObject.transform.position.y,
            pauseMenuObject.transform.position.z);
    }

    /// <summary>
    /// Pause Menu Code, also sets time to 0 when paused. This one is
    /// particularly better for deactivating.
    /// </summary>
    public void Pause()
    {
        // If the Pause Object is already active, it'll reset and resume!
        if (pauseMenuObject.activeSelf)
        {
            pauseMenuObject.SetActive(false);
            Time.timeScale = 1;
            powerup1.SetActive(true);
            powerup2.SetActive(true);
        }
        // If the Pause Object is not already active, it'll activate and pause!
        else
        {
            pauseMenuObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Return to Main Menu code via reusing the Win and Scene Behavior code.
    /// </summary>
    public void ReturnToMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        wASB = FindObjectOfType<WinAndSceneBehavior>();
        wASB.SceneChange();
    }
}
