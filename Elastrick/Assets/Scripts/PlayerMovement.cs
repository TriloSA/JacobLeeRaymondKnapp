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

Also harbors the enumerator to change colors FOR THE ALPHA. Not permanent!
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 rotation;
    PlayerActions pActions;
    
    PowerupManager pUM;
    InputActionMap pAM;

    InputActionAsset pActionInput;

    InputAction rotate;
    InputAction launch;

    [Header("Linkage")]
    [SerializeField] private Transform rotatePoint;
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Launch Check")]
    public bool canLaunch = true;
    public float catchTime;
    private Coroutine catchCoroutine;

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

    [Header("Unstick Boolean")]
    public bool onAWall;

    [Header("PowerUp Booleans")]
    public bool isSpeeding;

    /// <summary>
    /// On awake, link the playeractions and the "action keywords" to code
    /// variables.
    /// </summary>
    void Awake()
    {
        // Links pActions to PlayerActions
        pActions = new PlayerActions();

        pActionInput = this.GetComponent<PlayerInput>().actions;

        pAM = pActionInput.FindActionMap("PlayerActionMap");

        rotate = pAM.FindAction("Rotate");

        launch = pAM.FindAction("Launch");

        // Binds the Rotation of controller to rotation (vector2)
        rotate.performed += ctx => rotation =
        ctx.ReadValue<Vector2>();

        // Binds the Launch from player's action map to Launch();.
        launch.performed += ctx => Launch();
    }
    
    /// <summary>
    /// For linking purposes.
    /// </summary>
    private void Start()
    {
        pUM = GameObject.Find("GameManager").GetComponent<PowerupManager>();
    }

    /// <summary>
    /// Every frame, check if the player has rotated at all.
    /// </summary>
    void Update()
    {
        RotatePlayer();
    }

    /// <summary>
    /// On enable. Also prevents audio listeners to multiply.
    /// </summary>
    private void OnEnable()
    {
        int listenerCount = 0;

        foreach (AudioListener a in FindObjectsOfType<AudioListener>())
        {
            listenerCount++;

            if (listenerCount > 1)
            {
                a.enabled = false;
            }
        }

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
        rotatePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>
    /// If the player launches, they cannot shoot immediately again. Also 
    /// adds a force where the player is aiming.
    /// </summary>
    private void Launch()
    {
        if (this == null)
        {
            return;
        }

        // Just in case so that the wall DOESNT TRAVEL WITH THE PLAYER LOL.
        transform.SetParent(null);

        // Makes a raycast to check if there is something in front of the
        // player. Stores it in var h.
        var h = Physics2D.Raycast(transform.position, rotatePoint.right, 
        1f, ~LayerMask.GetMask("Player"));

        // If you can launch and you aren't raycast colliding into anything...
        if (canLaunch && h.collider == null)
        {
            if (catchCoroutine != null)
            {
                StopCoroutine(catchCoroutine);
            }
            canLaunch = false;
            Debug.Log("Boing!");
            rb2D.AddForce(rotation * launchVelocity, ForceMode2D.Impulse);
            isMoving = true;

            catchCoroutine = StartCoroutine(LaunchCatch());
        }
    }

    /// <summary>
    /// If 9 seconds passed and you CANT launch, you can launch again. 
    /// Anti-Safelock Measure.
    /// </summary>
    /// <returns></returns>
    IEnumerator LaunchCatch()
    {
        yield return new WaitForSeconds(catchTime);
        StartCoroutine(StopMovement());
    }

    /// <summary>
    /// Stop the player after collision via coroutine of StopMovement();
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Start color change.
        if (collision.gameObject.CompareTag("Powerup"))
        {
            StartCoroutine(ColorChange());
        }

        // If you cannot launch, stop your movement as you've likely hit a
        // wall or something.
        if (!canLaunch && stopColl == false)
        {
            StartCoroutine(StopMovement());
        }

        // If the collision game object is Wall, set the Player's parent to "Wall".
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Wall")
        {
            transform.SetParent(collision.gameObject.transform);
        }
    }

    /// <summary>
    /// Resets the player to be their own parent.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.SetParent(null);
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
        isSpeeding = true;
        launchVelocity *= amount;

        yield return new WaitForSeconds(time);

        Debug.Log("AAAAAA");
        pUM.ResetIcons();
        launchVelocity /= amount;
        isSpeeding = false;
    }

    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Color changes for powerups.
    /// </summary>
    /// <returns></returns>
    public IEnumerator ColorChange()
    {
        // If you're playing as player 1 and you got the speed powerup
        if (this.gameObject.GetComponent<PlayerBehavior>().isPlayer1 && 
        isSpeeding)
        {
            colorLink.GetComponent<SpriteRenderer>().color = Color.yellow;
            yield return new WaitForSeconds(5f);
            colorLink.GetComponent<SpriteRenderer>().color = Color.green;
        }

        // If you're playing as player 2 and you got the speed powerup
        else if (!this.gameObject.GetComponent<PlayerBehavior>().isPlayer1 && 
        isSpeeding)
        {
            colorLink.GetComponent<SpriteRenderer>().color = Color.magenta;
            yield return new WaitForSeconds(5f);
            colorLink.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        
    }
}