using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement main;

    private Camera mainCam;
    public Vector3 mousePos;
    public Transform aimTransform;
    public bool canFire = true;
    private float timer;
    public float fireCooldown;

    public bool hasCollided = true;



    // Start is called before the first frame update
    void Start()
    {
        mainCam = 
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

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

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > fireCooldown)
            {
                canFire = true;
                timer = 0;  
            }
        }

        if (Input.GetMouseButton(0) && canFire && hasCollided)
        {
            canFire = false;
            hasCollided = false;
            ShootScript.main.Shoot();
            Debug.Log(ShootScript.main.force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopAllCoroutines();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        StartCoroutine(TimeAfterCollision());
    }

    IEnumerator TimeAfterCollision()
    {
        yield return new WaitForSeconds(3);
        hasCollided = true;
        canFire = true;
    }
}
