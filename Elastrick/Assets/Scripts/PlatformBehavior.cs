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

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < TopY && goingDown == false)
        {
            movement = Vector3.up * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else if(transform.position.y >= TopY)
        {
            goingDown = true;
        }

        if(transform.position.y > BotY && goingDown == true)
        {
            movement = -(Vector3.up * speed * Time.deltaTime);
            transform.Translate(movement);
        }
        else if(transform.position.y <= BotY)
        {
            goingDown = false;
        }
    }
}
