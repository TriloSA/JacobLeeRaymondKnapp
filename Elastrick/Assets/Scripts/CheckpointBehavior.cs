/*****************************************************************************
// File Name :         CheckpointBehavior.cs
// Author :            Jacob Lee
// Creation Date :     April 13th, 2023
//
// Checkpoint Behavior. When a player collides with the trigger hitbox
of the Checkpoint, set their spawn point as this now!
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    public AudioClip checkpoint;

    public bool hasUnlockedP1;
    public bool hasUnlockedP2;

    /// <summary>
    /// On Trigger, set the new spawn coordinate values in relation to the 
    /// coordinates of the checkpoint gameobject's. The value is stored in a 
    /// vector 3 called newSpawn.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Safety measure.
        if (collision.gameObject.CompareTag("Player"))
        {
            // newSpawn's values is now the same as the checkpoint's.
            Vector3 newSpawn = this.gameObject.transform.position;
            
            // If they are player 1, spawn them on the left of the check point.
            // Otherwise, spawn them on the right.

            if (collision.gameObject.GetComponent<PlayerBehavior>().isPlayer1 && !hasUnlockedP1)
            {
                Debug.Log("Checkpoint Unlocked!");

                newSpawn = new Vector3(newSpawn.x - 1, newSpawn.y, newSpawn.z);
                // Checkpoint is now no longer collidable so you can't "unlock"
                // and older checkpoint. So keep moving, slacker!
                hasUnlockedP1 = true;

                AudioManager.inst.PlaySound(checkpoint);
                StartCoroutine(FlickerFlag());
            }
            else if (!collision.gameObject.GetComponent<PlayerBehavior>().isPlayer1 && !hasUnlockedP2)
            {
                Debug.Log("Checkpoint Unlocked!");

                newSpawn = new Vector3(newSpawn.x + 1, newSpawn.y, newSpawn.z);
                // Checkpoint is now no longer collidable so you can't "unlock"
                // and older checkpoint. So keep moving, slacker!
                hasUnlockedP2 = true;

                AudioManager.inst.PlaySound(checkpoint);
                StartCoroutine(FlickerFlag());
            }

            // Value X
            collision.gameObject.GetComponent<PlayerBehavior>().xVal = 
            newSpawn.x;
            // Value Y
            collision.gameObject.GetComponent<PlayerBehavior>().yVal = 
            newSpawn.y;
        }

        /// <summary>
        /// Flickers flag by waiting 0.3 second intervals and changing colors
        /// </summary>
        /// <returns></returns>
        IEnumerator FlickerFlag()
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = 
            new Color(0, 0, 0, 255);
            yield return new WaitForSeconds(0.3f);
            this.gameObject.GetComponent<SpriteRenderer>().color =
            new Color(255, 255, 255, 255);
            yield return new WaitForSeconds(0.3f);
            this.gameObject.GetComponent<SpriteRenderer>().color =
            new Color(0, 0, 0, 255);
            yield return new WaitForSeconds(0.3f);
            this.gameObject.GetComponent<SpriteRenderer>().color =
            new Color(255, 255, 255, 255);
        }
    }

    /// <summary>
    /// Prevents any softlocking from raycasting.
    /// </summary>
    private void Update()
    {
        if (hasUnlockedP1 & hasUnlockedP2)
        {
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
