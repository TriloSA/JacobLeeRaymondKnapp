using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    PlayerBehavior pB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("i did something!");
            Vector3 obama = this.gameObject.transform.position;
            Debug.Log(obama);
            collision.gameObject.GetComponent<PlayerBehavior>().xVal = obama.x;
            collision.gameObject.GetComponent<PlayerBehavior>().yVal = obama.y;
        }
    }
}
