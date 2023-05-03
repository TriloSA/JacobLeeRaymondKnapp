/*****************************************************************************
// File Name :         PowerupManager.cs
// Author :            Jacob Lee
// Creation Date :     April 12th, 2023
//
// The script that randomizes and applies a powerup on the player who hit
the powerup using random number generators (random.range) and enumerators.

Changes colors whenever power ups activate.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
    private PlayerMovement pM;
    private PlayerBehavior pB;
    public GameObject playerInQuestion;

    // Holds the image for player 1 and player 2 for UI.
    public Image imageHolder1;
    public Image imageHolder2;

    public Sprite speedUp;
    public Sprite damageUp;
    public AudioClip rouletteSound;

    //Temp Audio
    public AudioClip tempPowerUp;

    /// <summary>
    /// Randomizes the powerup given internally using Random.Range.
    /// </summary>
    /// <returns></returns>
    public int PickPowerup()
    {
        // Currently only allows the 2 possible powerups.
        return Random.Range(1, 3);
    }

    /// <summary>
    /// Visually, the player will see the item roulette, but internally, it 
    /// adds aritifical time to let the graphics catch up.
    /// 
    /// Also enables/disables a boolean checking if the player has a powerup
    /// active or not.
    /// </summary>
    /// <returns></returns>
    public IEnumerator timeForRoulette() //THIS ONE IS FOR RANDOM.
    {
        // Recieves Players's reference and stores it.
        pM = playerInQuestion.GetComponent<PlayerMovement>();
        pB = playerInQuestion.GetComponent<PlayerBehavior>();
        // The player cannot get another powerup while one is active.
        pM.hasAPowerUp = true;

        // Roulette time.

        // Temporary Audio:
        AudioManager.inst.PlaySound(tempPowerUp);

        //AudioManager.inst.PlaySound(rouletteSound);
        // Bugs out the system. Need FIX. -> //yield return new WaitForSecondsRealtime(4.25f);

        // Defines which powerup is applied, AKA the magic.
        switch (PickPowerup())
        {
            // If it's initial bounce power up.
            case 1:
                if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == true)
                {
                    imageHolder1.sprite = speedUp;
                }
                else if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == false)
                {
                    imageHolder2.sprite = speedUp;
                }

                pM.StartCoroutine(pM.SpeedInc(2, 6));
                break;

            // If it's damage power up.
            case 2:
                if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == true)
                {
                    imageHolder1.sprite = damageUp;
                }
                else if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == false)
                {
                    imageHolder2.sprite = damageUp;
                }

                pB.StartCoroutine(pB.UpDamage(2, 8));
                break;
        }
        yield return null; //Bandaid to the Yield Return WaitForSeconds above.

        // FOR ALPHA: COLOR CHANGE SCRIPT
        pM.StartCoroutine(pM.ColorChange());
    }


    /// <summary>
    /// Same thing as the other timeForRoulette but is specifically tailored for the tutorial and is specific.
    /// </summary>
    /// <param name="powerUp"></param>
    /// <returns></returns>
    public IEnumerator timeForRoulette(int powerUp) 
    // THIS ONE IS FOR SPECIFIC. IF YOU WANT SPECIFIC, YOU CHECK THE BOX IN INSPECTOR AND GIVE IT A VALUE FOR INT.
    {
        // Recieves PowerupBehavior's reference and stores it.
        pM = playerInQuestion.GetComponent<PlayerMovement>();
        pB = playerInQuestion.GetComponent<PlayerBehavior>();
        // The player cannot get another powerup while one is active.
        pM.hasAPowerUp = true;

        Debug.Log(pM.hasAPowerUp);

        // Roulette time.

        // Temporary Audio:
        AudioManager.inst.PlaySound(tempPowerUp);

        //AudioManager.inst.PlaySound(rouletteSound);
        // Bugs out the system. Need FIX. -> //yield return new WaitForSecondsRealtime(4.25f);

        // Defines which powerup is applied, AKA the magic.
        switch (powerUp)
        {
            // If it's initial bounce power up.
            case 1:
                if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == true)
                {
                    imageHolder1.sprite = speedUp;
                }
                else if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == false)
                {
                    imageHolder2.sprite = speedUp;
                }

                pM.StartCoroutine(pM.SpeedInc(2, 5));
                break;

            // If it's damage power up.
            case 2:
                if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == true)
                {
                    imageHolder1.sprite = damageUp;
                }
                else if (playerInQuestion.GetComponent<PlayerBehavior>().isPlayer1 == false)
                {
                    imageHolder2.sprite = damageUp;
                }

                pB.StartCoroutine(pB.UpDamage(2, 5));
                break;
        }
        yield return null; //Bandaid to the Yield Return WaitForSeconds above.
        
        // FOR ALPHA: COLOR CHANGE SCRIPT
        pM.StartCoroutine(pM.ColorChange());
    }
}