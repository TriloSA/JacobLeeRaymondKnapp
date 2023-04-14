using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float xVal = -16f;
    public float yVal = -7f;
    public int lives = 3;

    public void Start()
    {
        xVal = -16f;
        yVal = -7f;
    }

    /// <summary>
    ///  recognizes when player collides with obstacles,
    ///  and tells the Game Controller to run the UpdateLives function
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            lives--;
        }
    }

    private void Update()
    {
        if(lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        this.gameObject.GetComponent<PlayerMovement>().canLaunch = true;
        this.gameObject.GetComponent<PlayerMovement>().isMoving = false;
        this.gameObject.GetComponent<PlayerMovement>().hasAPowerUp = false;

        lives = 3;

        if (xVal != -16f && yVal != -7f)
        {
            gameObject.transform.position = new Vector2(xVal, yVal);
        }
        else
        {
            gameObject.transform.position = new Vector2(-16f, -7f);
        }
        
    }

}
