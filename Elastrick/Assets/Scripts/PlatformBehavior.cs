using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    public float TopY;
    public float BottomY;
    public static float speed;

    private void Update()
    {
        if(gameObject.transform.position.y >= TopY)
        {
            
        }
    }
}
