using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement: MonoBehaviour
{
    Vector2 rotation;
    PlayerActions pActions;

    [Header("Linkage")]
    [SerializeField] private GameObject rotObject;
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Launch Check")]
    [SerializeField] private bool canLaunch = true;

    [Header("Speed")]
    [SerializeField] private float launchVelocity = 300f;

    // For stopping on collision.
    private bool check;

    // Start is called before the first frame update
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

    // Every frame, check if the player has rotated at all.
    void Update()
    {
        RotatePlayer();
    }
    
    // On enable.
    private void OnEnable()
    {
        pActions.PlayerActionMap.Enable();
    }
    
    // On disable.
    private void OnDisable()
    {
        pActions.PlayerActionMap.Disable();
    }

    // Rotates the player.
    private void RotatePlayer()
    {
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // If the player launches, they cannot shoot immediately again. Also
    // adds a force where the player is aiming.
    private void Launch()
    {
        if (canLaunch)
        {
            canLaunch = false;
            Debug.Log("Boing!");
            rb2D.AddForce(rotObject.transform.right * launchVelocity);
        }


    }

    // Stop the player after collision.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If you cannot launch, stop your movement as you've likely hit a
        // wall or something.
        if(!canLaunch && check == false)
        {
            StartCoroutine(StopMovement());
        }
    }

    // Stops movement, then after 0.1 seconds (to allow graphic to catch up to
    // unity's behind the scenes mathematics, allows the user to relaunch.
    IEnumerator StopMovement()
    {
        check = true;
        rb2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
        canLaunch = true;
        check = false;
    }
}
