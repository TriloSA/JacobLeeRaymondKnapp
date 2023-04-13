/*****************************************************************************
// File Name :         PowerupManager.cs
// Author :            Jacob Lee
// Creation Date :     April 12th, 2023
//
// The script that randomizes and applies a powerup on the player who hit
the powerup using random number generators (random.range) and enumerators.

Also for the ALPHA only, changes the colors to visually show its effect in
action.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private PlayerMovement pM;
    public GameObject playerInQuestion;

    /// <summary>
    /// Randomizes the powerup given internally using Random.Range.
    /// </summary>
    /// <returns></returns>
    public int PickPowerup()
    {
        // Currently only allows the speed to be a possible powerup.
        return Random.Range(1, 2);
    }

    /// <summary>
    /// Visually, the player will see the item roulette, but internally, it 
    /// adds aritifical time to let the graphics catch up.
    /// 
    /// Also enables/disables a boolean checking if the player has a powerup
    /// active or not.
    /// </summary>
    /// <returns></returns>
    public IEnumerator timeForRoulette()
    {
        // Recieves PowerupBehavior's reference and stores it.
        pM = playerInQuestion.GetComponent<PlayerMovement>();
        // The player cannot get another powerup while one is active.
        pM.hasAPowerUp = true;

        // Roulette time.
        yield return new WaitForSecondsRealtime(4.25f);

        // Defines which powerup is applied, AKA the magic.
        switch (PickPowerup())
        {
            case 1:
                pM.StartCoroutine(pM.SpeedInc(2, 5));
                break;
            case 2:
                UpDamage(pM);
                break;
        }

        // The player no longer has a powerup and can safely get a new one.
        pM.hasAPowerUp = false;

        // FOR ALPHA: COLOR CHANGE SCRIPT
        pM.StartCoroutine(pM.ColorChangeForTheAlpha());
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
}