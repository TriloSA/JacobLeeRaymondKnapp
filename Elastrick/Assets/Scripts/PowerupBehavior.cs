/*****************************************************************************
// File Name :         PowerupBehavior.cs
// Author :            Jacob Lee
// Creation Date :     April 10th, 2023
//
// Behavior for the powerup game objects. On collision, generates a random
powerup using a switch case and random.range. Powerups have different effects.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
    private PlayerMovement pM;

    /// <summary>
    /// Randomizes the item internally using Random.Range.
    /// </summary>
    /// <returns></returns>
    public int PickPowerup()
    {
        return Random.Range(1, 2);
    }

    /// <summary>
    /// not functional at the moment.
    /// </summary>
    /// <param name="pm"></param>
    private void UpDamage(PlayerMovement pm)
    {
        //playerDamage++
        Debug.Log("Well, nothing happened.");
    }

    /// <summary>
    /// On Collision (Trigger), start the powerup sequence via if statements
    /// and switch statements
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pM = collision.gameObject.GetComponent<PlayerMovement>();

            // If you have a powerup, you can't pick it up.
            if (pM.hasAPowerUp == false)
            {
                StartCoroutine(timeForRoulette());
            }
        }
    }

    /// <summary>
    /// Visually, the player sees the item roulette, but internally, it adds
    /// aritifical time to let the graphics catch up.
    /// </summary>
    /// <returns></returns>
    IEnumerator timeForRoulette()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        pM.hasAPowerUp = true;

        yield return new WaitForSeconds(4.25f);

        switch (PickPowerup())
        {
            case 1:
                pM.StartCoroutine(pM.SpeedInc(2, 5));
                StartCoroutine(pM.ColorChangeForTheAlpha());
                break;
            case 2:
                UpDamage(pM);
                break;
        }

        Debug.Log("you've been sped up!");
        pM.hasAPowerUp = false;
        Destroy(gameObject);
    }

}
