/*****************************************************************************
// File Name :         PlayerBehavior.cs
// Author :            Jacob Lee
// Creation Date :     April 13th, 2023
//
// Essentailly the health system, tracks if player has hit a damaging
obstacle, as well as if they died. Works in tandem with CheckpointBehavior.cs.
If player has died, respawn them.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float xVal = -16f;
    public float yVal = -7f;
    public int lives = 3;

    /// <summary>
    /// Set's the default spawn values.
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
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            lives--;
        }
    }
    
    /// <summary>
    /// If your lives ever drop below 0 or is equal to 0, perish.
    /// </summary>
    private void Update()
    {
        if(lives <= 0)
        {
            DieAndRespawn();
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
