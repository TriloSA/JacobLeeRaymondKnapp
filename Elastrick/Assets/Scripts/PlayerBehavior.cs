using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    ///  recognizes when player collides with obstacles,
    ///  and tells the Game Controller to run the UpdateLives function
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameController gc = FindObjectOfType<GameController>();

        if(collision.gameObject.tag == "Obstacle")
        {
            gc.UpdateLives();
        }

        if(collision.gameObject.tag == "Player")
        {
            gc.UpdateLives();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
