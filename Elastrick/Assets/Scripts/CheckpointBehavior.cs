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
            //Debug.Log("i did something!");
            // newSpawn's values is now the same as the checkpoint's.
            Vector3 newSpawn = this.gameObject.transform.position;

            // Value X
            collision.gameObject.GetComponent<PlayerBehavior>().xVal = 
            newSpawn.x;
            // Value Y
            collision.gameObject.GetComponent<PlayerBehavior>().yVal = 
            newSpawn.y;
        }
    }
}
