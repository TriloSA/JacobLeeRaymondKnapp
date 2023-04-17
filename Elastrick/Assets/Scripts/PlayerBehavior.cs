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

    [Header("Invinciblity Frames")]
    public bool isInvincible = false;

    [Header("Determining of Player 1")]
    public bool isPlayer1 = false;
    public static bool hasPlayer1 = false;

    /// <summary>
    /// Set's the default spawn values upon spawn.
    /// </summary>
    public void Start()
    {
        // Default unchanged values for spawn.
        xVal = -15f;
        yVal = -7f;

        // First player instantiated is Player 1. Everything that happens here
        // should only apply to player 1.
        if (!hasPlayer1)
        {
            xVal += -2f;
            isPlayer1 = true;
            hasPlayer1 = true;
        }

        // Their position is now xVal and yVal.
        transform.position = new Vector2(xVal, yVal);
    }

    /// <summary>
    ///  On collision with an obstacle, lose a life.
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If you hit an obstacle, lose a life.
        if (collision.gameObject.CompareTag("Obstacles") && !isInvincible)
        {
            // Player takes damage.
            lives--;

            GiveIFrames();
        }
        
        // If you hit a player while moving, make them lose a life.
        // Only the player moving will not get hit, in order to serve as hit
        // priority and to NOT make both players take damage.
        if (collision.gameObject.CompareTag("Player") && 
            this.gameObject.GetComponent<PlayerMovement>().isMoving == true &&
            !collision.gameObject.GetComponent<PlayerBehavior>().isInvincible)
        {
            collision.gameObject.GetComponent<PlayerBehavior>().lives--;

            collision.gameObject.GetComponent<PlayerBehavior>().GiveIFrames();
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
        GiveIFrames();

        this.gameObject.GetComponent<PlayerMovement>().canLaunch = true;
        this.gameObject.GetComponent<PlayerMovement>().isMoving = false;
        this.gameObject.GetComponent<PlayerMovement>().hasAPowerUp = false;

        // Resets your HP internally and visually.
        lives = 3;
        
        // Respawn the player back to their original psoiton (whether it be
        // spawn or their checkpoint location).
        gameObject.transform.position = new Vector2(xVal, yVal);
    }

    /// <summary>
    /// Sets boolean back to making the player be able to be hittable after X
    /// amount of time.
    /// </summary>
    public void IsHittable()
    {
        Debug.Log("You CAN get hurt.");
        isInvincible = false;
    }

    /// <summary>
    /// Makes the player invincible and runs IsHittable after 2 seconds to
    /// revert IFrames.
    /// </summary>
    public void GiveIFrames()
    {
        Debug.Log("you can't get hurt!");
        // Player gets Immunity frames upon respawn.
        isInvincible = true;
        Invoke("IsHittable", 2f);
    }
}
