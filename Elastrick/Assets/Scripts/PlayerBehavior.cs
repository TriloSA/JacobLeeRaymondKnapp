/*****************************************************************************
// File Name :         PlayerBehavior.cs
// Author :            Jacob Lee
// Creation Date :     April 13th, 2023
//
// Essentailly the health system, tracks if player has hit a damaging
obstacle, as well as if they died. Works in tandem with CheckpointBehavior.cs.
If player has died, respawn them.

Also adds the visual UI indiacation of HP elements through game objects
embedded onto the player.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header ("Player's Spawn Values & Lives")]
    public float xVal = -16f;
    public float yVal = -7f;
    public int lives = 3;

    [Header ("HP UI GameObjects")]
    public GameObject threeHPValue;
    public GameObject twoHPValue;
    public GameObject oneHPValue;


    /// <summary>
    /// Set's the default spawn values upon spawn.
    /// </summary>
    public void Start()
    {
        xVal = -16f;
        yVal = -7f;
    }

    /// <summary>
    ///  On collision with an obstacle, lose a life.
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If you hit an obstacle, lose a life.
        if (collision.gameObject.CompareTag("Obstacles") || 
            collision.gameObject.CompareTag("Player"))
        {
            lives--;
        }
        
        // If you hit a player while moving, make them lose a life.
        // Only the player moving will not get hit, in order to serve as hit
        // priority and to NOT make both players take damage.
        if (collision.gameObject.CompareTag("Player") && 
            this.gameObject.GetComponent<PlayerMovement>().isMoving == true)
        {
            collision.gameObject.GetComponent<PlayerBehavior>().lives--;
        }
    }
    
    /// <summary>
    /// If your lives ever drop below 0 or is equal to 0, perish.
    /// </summary>
    private void Update()
    {
        // If you lose all your lives, you die and respawn.
        if(lives <= 0)
        {
            DieAndRespawn();
        }

        // If your lives are at 3, your character should display a 3 HP value.
        if (lives == 3)
        {
            threeHPValue.SetActive(true);
            twoHPValue.SetActive(false);
            oneHPValue.SetActive(false);
        }
        // If your lives are at 2, your character should display a 2 HP value.
        else if (lives == 2)
        {
            threeHPValue.SetActive(false);
            twoHPValue.SetActive(true);
            oneHPValue.SetActive(false);
        }
        // If your lives are at 1, your character should display a 1 HP value.
        else if (lives == 1)
        {
            threeHPValue.SetActive(false);
            twoHPValue.SetActive(false);
            oneHPValue.SetActive(true);
        }
    }

    /// <summary>
    /// Once player dies, reset everything (from spawn values and their
    /// booleans that govern whether or not they can do an action to be
    /// defaulted so they can move again, as well as lives to 3 again.
    /// </summary>
    private void DieAndRespawn()
    {
        this.gameObject.GetComponent<PlayerMovement>().canLaunch = true;
        this.gameObject.GetComponent<PlayerMovement>().isMoving = false;
        this.gameObject.GetComponent<PlayerMovement>().hasAPowerUp = false;

        // Resets your HP internally and visually.
        lives = 3;

        // If the value isn't spawn's values, spawn there.
        if (xVal != -16f && yVal != -7f)
        {
            gameObject.transform.position = new Vector2(xVal, yVal);
        }
        // Else, spawn at spawn values.
        else
        {
            gameObject.transform.position = new Vector2(-16f, -7f);
        }
        
    }

}
