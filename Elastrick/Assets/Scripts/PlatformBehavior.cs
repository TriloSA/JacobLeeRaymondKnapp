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

    // For a prototype system of platform movement that does not use
    // transform.translate. Anything using newMovement is under this idea.
    // - Jacob Lee
    [Space]
    private Transform nextPos;
    public bool newMovement = false;
    [SerializeField] private Transform posA, posB;

    /// <summary>
    /// Prototype for new movement. Does nothing currently. - Jacob Lee
    /// </summary>
    private void Start()
    {
        if(newMovement)
        {
            nextPos = posA;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// 
    /// this code checks if the moving platform has reached the top, or bottom,
    /// value. and once it reaches the value, turn it around and move towards
    /// the other set value.
    /// </summary>
    void Update()
    {
        // Prototype. Does nothing currently. - Jacob Lee
        if(newMovement)
        {
            if (transform.position == nextPos.position && nextPos == posA)
            {
                nextPos = posB;
            }

            if (transform.position == nextPos.position && nextPos == posB)
            {
                nextPos = posA;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }

        if(newMovement)
        {
            return;
        }

        //this checks if the moving platform has reached the TopY value
        //if the platform has reached the TopY, goingDown will be set to true
        //which makes the moving platform move towards the BotY value
        if(transform.position.y < TopY && goingDown == false)
        {
            movement = Vector3.up * speed * Time.deltaTime;
            transform.Translate(movement);
            //rB2D.velocity = movement;
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
            //rB2D.velocity = movement;
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
        // Platforms ignore the wall if they so collide with it.
        if (!collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());

            foreach (Collider2D c in GetComponentsInChildren<Collider2D>())
            {
                Physics2D.IgnoreCollision(collision.collider, c);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            // You are now on a wall.
            collision.gameObject.GetComponent<PlayerMovement>().onAWall = true;

            // You now move with the wall.
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = movement;
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
            // You are no longer on a wall.
            collision.gameObject.GetComponent<PlayerMovement>().onAWall = false;

            // You immediately slow after being pushed off the wall if you were sliding off the top of it.
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
