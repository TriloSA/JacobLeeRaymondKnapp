/*****************************************************************************
// File Name :         TutorialCombatScript.cs
// Author :            Jacob Lee
// Creation Date :     April 10th, 2023
//
// Tutorial Combat Script for the tutorial that demonstrates how to use the
damage power up. Once you kill the other player, you unlock the door!
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCombatScript : MonoBehaviour
{
    public GameObject checkBox;
    public GameObject lockedDoor;

    public bool tutorialPlayerCombatCheck = false;
    public bool hasGottenToThisPoint = false;

    /// <summary>
    /// If you hit the trigger invisible box, you are now elligble to open
    /// the locked door.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasGottenToThisPoint = true;
            checkBox.GetComponent<BoxCollider2D>().enabled = false;
            //Debug.Log("tasktask123");
        }
    }

    /// <summary>
    /// If you killed someone at that zone with the powerup, you can complete
    /// the tutorial.
    /// </summary>
    private void Update()
    {
        if (tutorialPlayerCombatCheck)
        {
            lockedDoor.SetActive(false);
        }
    }
}
