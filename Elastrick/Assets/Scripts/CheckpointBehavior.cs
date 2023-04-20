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
            Debug.Log("Checkpoint Unlocked!");

            StartCoroutine(FlickerFlag());

            // Checkpoint is now no longer collidable so you can't "unlock"
            // and older checkpoint. So keep moving, slacker! NOTE: This will
            // CURRENTLY NOT work in 2 player since it will disable for the
            // other player.
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            // newSpawn's values is now the same as the checkpoint's.
            Vector3 newSpawn = this.gameObject.transform.position;
            
            // If they are player 1, spawn them on the left of the check point.
            // Otherwise, spawn them on the right.
            if (collision.gameObject.GetComponent<PlayerBehavior>().isPlayer1)
            {
                newSpawn = new Vector3(newSpawn.x - 1, newSpawn.y, newSpawn.z);
            }
            else
            {
                newSpawn = new Vector3(newSpawn.x + 1, newSpawn.y, newSpawn.z);
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
}
