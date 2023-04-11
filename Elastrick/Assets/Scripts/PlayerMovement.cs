/*****************************************************************************
// File Name :         PlayerMovement.cs
// Author :            Jacob Lee
// Creation Date :     April 10th, 2023
//
// Movement script for the player. Rotates the player using controller and the
player actions. That rotation is saved and referenced with the launch, as it
adds a force to move towards the selected direction of where the ball is
facing, primarilly shown visually by the pointer that rotates around the
player as a child object.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 rotation;
    PlayerActions pActions;

    [Header("Linkage")]
    [SerializeField] private GameObject rotObject;
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Launch Check")]
    [SerializeField] private bool canLaunch = true;

    [Header("Moving Check")]
    public bool isMoving;

    [Header("Speed")]
    [SerializeField] private float launchVelocity = 300f;

    // For stopping on collision.
    private bool check;

    // For anti powerup spam protection.
    public bool hasAPowerUp;

    /// <summary>
    /// On awake, link the playeractions and the "action keywords" to code
    /// variables.
    /// </summary>
    void Awake()
    {
        // Links pActions to PlayerActions
        pActions = new PlayerActions();

        // Binds the Rotation of controller to rotation (vector2)
        pActions.PlayerActionMap.Rotate.performed += ctx => rotation =
        ctx.ReadValue<Vector2>();

        // Binds the Launch from player's action map to Launch();.
        pActions.PlayerActionMap.Launch.performed += ctx => Launch();
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
        pActions.PlayerActionMap.Enable();
    }

    /// <summary>
    /// On disable.
    /// </summary>
    private void OnDisable()
    {
        pActions.PlayerActionMap.Disable();
    }

    /// <summary>
    /// Rotates the player by transforming their rotation in accordance to
    /// the positioning of the controller.
    /// </summary>
    private void RotatePlayer()
    {
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>
    /// If the player launches, they cannot shoot immediately again. Also 
    /// adds a force where the player is aiming.
    /// </summary>
    private void Launch()
    {
        if (canLaunch)
        {
            canLaunch = false;
            //Debug.Log("Boing!");
            rb2D.AddForce(rotObject.transform.right * launchVelocity);
            isMoving = true;
        }
    }

    /// <summary>
    /// Stop the player after collision via coroutine of StopMovement();
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided!");
        // If you cannot launch, stop your movement as you've likely hit a
        // wall or something.
        if (!canLaunch && check == false)
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
        check = true;
        rb2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.4f);
        canLaunch = true;
        check = false;
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

    /// <summary>
    /// For the alpha sake, this is a visual indicator of how long you got your powerup for.
    /// </summary>
    /// <returns></returns>
    public IEnumerator ColorChangeForTheAlpha()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(5f);
        pO.GetComponent<SpriteRenderer>().color = Color.white;
        //BUG: WONT CHANGE COLOR BACK TO WHITE
        // MAYBE BECAUSE THE OBJECT OF POWERUP IS GONE?
        //BUG: COLLISIONS NOT WORKING AND CAN BOUNCE ON AIR
        //BUG: PLAYER SLOWS BEFORE HITTING WALL

    }
}