using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public TMP_Text livesText;
    public int Lives;

    public GameObject player1;

    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.Instantiate(player1, 0, null, pairWithDevice: Gamepad.all[0]);
    }

    /// <summary>
    /// when a player runs into an obstacle,
    /// the lives counter goes down by -1
    /// </summary>
    public void UpdateLives()
    {
        Lives -= 1;
        livesText.text = "Lives: " + Lives;

    }

    public void RespawnPlayer()
    {
        if(Lives <= 0)
        {

        }
    }

    /// <summary>
    /// for debugging
    /// if escape key is clicked, the app should close
    /// if the r key is clicked, the game should load the main menu
    /// </summary>
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
    }
}
