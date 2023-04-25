/*****************************************************************************
// File Name :         PlatformBehavior.cs
// Author :            Raymond Knapp
// Creation Date :     April 13th, 2023
//
// Movement script for the moving platform GameObjects. This code essentially tells
// the platforms to move up on the y-axis until it reaches a certain value. And once it reaches 
// the top value, move down to the bottom value. And finally, upon reaching the 
// bottom value, move up towards the top value.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    public float TopY;
    public float BotY;

    public float speed = 2f;

    public Vector3 movement;

    private bool goingDown = false;

    /// <summary>
    /// Update is called once per frame
    /// 
    /// this code checks if the moving platform has reached the top, or bottom,
    /// value. and once it reaches the value, turn it around and move towards
    /// the other set value.
    /// </summary>
    void Update()
    {
        //this checks if the moving platform has reached the TopY value
        //if the platform has reached the TopY, goingDown will be set to true
        //which makes the moving platform move towards the BotY value
        if(transform.position.y < TopY && goingDown == false)
        {
            movement = Vector3.up * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else if(transform.position.y >= TopY)
        {
            goingDown = true;
        }

        //this checks if the moving platform has reached the BotY value
        //if the platform has reached the BotY, goingDown will be set to false
        //which makes the moving platform move towards the TopY value
        if (transform.position.y > BotY && goingDown == true)
        {
            movement = -(Vector3.up * speed * Time.deltaTime);
            transform.Translate(movement);
        }
        else if(transform.position.y <= BotY)
        {
            goingDown = false;
        }
    }

    /// <summary>
    /// Jacob Lee: Player becomes a child and now is riding the wall.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<PlayerMovement>().onAWall = true;
        }
    }

    /// <summary>
    /// Jacob Lee: Player becomes it's own parent and is no longer riding the
    /// wall.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.GetComponent<PlayerMovement>().onAWall = false;
        }
    }
}
