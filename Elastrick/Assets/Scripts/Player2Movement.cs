/*****************************************************************************
// File Name :         Player2Movement.cs
// Author :            Ray Knapp
// Creation Date :     April 24th, 2023
//
// Movement script for the second player. Rotates the player using controller and the
player actions. That rotation is saved and referenced with the launch, as it
adds a force to move towards the selected direction of where the ball is
facing, primarilly shown visually by the pointer that rotates around the
player as a child object.

Also harbors the enumerator to change colors FOR THE ALPHA. Not permanent!
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player2Movement : MonoBehaviour
{
    Vector2 rotation;
    Player2Actions p2Actions;

    [Header("Linkage")]
    [SerializeField] private Transform rotatePoint;
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Launch Check")]
    public bool canLaunch = true;

    [Header("Moving Check")]
    public bool isMoving;

    [Header("Speed")]
    [SerializeField] private float launchVelocity = 300f;

    [Header("Color Link")]
    [SerializeField] private GameObject colorLink;

    [Header("Stop Collision Check Bool")]
    // For stopping on collision.
    [SerializeField] private bool stopColl;

    [Header("Anti-Powerup Spam Check")]
    // For anti powerup spam protection.
    public bool hasAPowerUp;

    /// <summary>
    /// On awake, link the playeractions and the "action keywords" to code
    /// variables.
    /// </summary>
    void Awake()
    {

        // Links pActions to PlayerActions
        p2Actions = new Player2Actions();

        // Binds the Rotation of controller to rotation (vector2)
        p2Actions.PlayerActions2.Rotate.performed += ctx => rotation =
        ctx.ReadValue<Vector2>();

        // Binds the Launch from player's action map to Launch();.
        p2Actions.PlayerActions2.Launch.performed += ctx => Launch();
    }

    /// <summary>
    /// Every frame, check if the player has rotated at all.
    /// </summary>
    void Update()
    {
        RotatePlayer();
    }

    /// <summary>
    /// On enable.
    /// </summary>
    private void OnEnable()
    {
        p2Actions.PlayerActions2.Enable();
    }

    /// <summary>
    /// On disable.
    /// </summary>
    private void OnDisable()
    {
        p2Actions.PlayerActions2.Disable();
    }

    /// <summary>
    /// Rotates the player by transforming their rotation in accordance to
    /// the positioning of the controller.
    /// </summary>
    private void RotatePlayer()
    {
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        rotatePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>
    /// If the player launches, they cannot shoot immediately again. Also 
    /// adds a force where the player is aiming.
    /// </summary>
    private void Launch()
    {
        // Makes a raycast to check if there is something in front of the
        // player. Stores it in var h.
        var h = Physics2D.Raycast(transform.position, rotatePoint.right,
        1f, ~LayerMask.GetMask("Player"));

        // If you can launch and you aren't raycast colliding into anything...
        if (canLaunch && h.collider == null)
        {
            canLaunch = false;
            Debug.Log("Boing!");
            rb2D.AddForce(rotation * launchVelocity, ForceMode2D.Impulse);
            isMoving = true;
        }
    }

    /// <summary>
    /// Stop the player after collision via coroutine of StopMovement();
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // uhh mr alex.
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("hi i am alex koeberl, and you're watching the disney " +
            "channel");
            StartCoroutine(ColorChangeForTheAlpha());
        }

        // If you cannot launch, stop your movement as you've likely hit a
        // wall or something.
        if (!canLaunch && stopColl == false)
        {
            StartCoroutine(StopMovement());
        }
    }

    /// <summary>
    /// Stops movement, then after 0.1 seconds (to allow graphic to catch up 
    /// to unity's behind the scenes mathematics, allows the user to relaunch.
    /// </summary>
    /// <returns></returns>
    IEnumerator StopMovement()
    {
        stopColl = true;
        rb2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.4f);
        canLaunch = true;
        stopColl = false;
        isMoving = false;
    }

    /// <summary>
    /// Increases Speed for Powerups. Multiplier for Speed and then after
    /// # amount of time occurs, revert changes. No direct functionality in
    /// this script, but is used in PowerupBehavior.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public IEnumerator SpeedInc(float amount, float time)
    {
        launchVelocity *= amount;

        yield return new WaitForSeconds(time);

        launchVelocity /= amount;
    }

    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// For the alpha sake, this is a visual indicator of how long you got
    /// your powerup for.
    /// </summary>
    /// <returns></returns>
    public IEnumerator ColorChangeForTheAlpha()
    {
        Debug.Log("hello my name is alexiplier");
        colorLink.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(5f);
        Debug.Log("and welcome back to another video of five nights at " +
        "freddys");
        colorLink.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
