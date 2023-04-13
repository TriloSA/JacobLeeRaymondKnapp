using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public static ShootScript main;

    //private Vector3 mousePos;
    //private Camera mainCamera;
    private Rigidbody2D rb2d;
    public float force;

    private PlayerMovement _pm;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _pm = GetComponent<PlayerMovement>();
    }

    // Linkage.
    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Shoot()
    {
        Vector3 direction = _pm.mousePos - transform.position;
        Vector3 rotation = transform.position - _pm.mousePos;
        /*   rb2d.velocity = new Vector2(direction.x, direction.y).normalized
                * force;*/


        Vector2 newForce = new Vector2(direction.x * force, direction.y * force).normalized * force;
        rb2d.AddForce(newForce);

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
}
