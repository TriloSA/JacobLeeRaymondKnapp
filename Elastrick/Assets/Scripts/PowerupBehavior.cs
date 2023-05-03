/*****************************************************************************
// File Name :         PowerupBehavior.cs
// Author :            Jacob Lee
// Creation Date :     April 10th, 2023
//
// Behavior on the power up game objects. Tells the Game Manager what player
interacted with the power up and who to apply the power up to. Then safely
destroys the game object silently and hidden.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
    private PlayerMovement pM;
    private PowerupManager pUM;

    public bool specificPowerup;
    public int powerUpIndex;

    /// <summary>
    /// Links the game manager to this script so it can pass references.
    /// </summary>
    private void Start()
    {
        pUM = GameObject.Find("GameManager").GetComponent<PowerupManager>();
    }


    /// <summary>
    /// On Collision (Trigger), start the powerup sequence. Gives references
    /// of which player hit the power up and who to give the powerup to.
    /// Then, safely destroys the powerup hidden from the gameview.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pM = collision.gameObject.GetComponent<PlayerMovement>();

            // If you have a powerup, you can't pick it up.
            if (!pM.hasAPowerUp)
            {
                // The player in question is the one who collided with it.
                pUM.playerInQuestion = collision.gameObject;

                if (specificPowerup)
                {
                    StartCoroutine(pUM.timeForRoulette(powerUpIndex));
                }
                else
                {
                    // Starts the powerup coroutine.
                    StartCoroutine(pUM.timeForRoulette());
                }
                

                // Visually, hides the power up.
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                // Waits a while to properly and safely deload the used
                // power ups.
                Destroy(gameObject, 8f);
            }
        }
    }
}
