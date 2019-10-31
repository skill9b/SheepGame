using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class testArcBulletController : MonoBehaviour
{
    public float xDistance;

    float velocityX;
    float velocityY;


    private void Start()
    {
        float t = 1;
        float s = 3;

        xDistance = xDistance / 1.60f;

        // Calculate init x velocity
        // s = ut + (0.5 * a * t^2)
        // s = ut
        // u = s / t
        velocityX = xDistance / t; 
        Debug.Log("x velocity: " + velocityX);


        // Calculate init y velocity
        // s = ut + (0.5 * a * t^2)
        // 10 = u * t + (0.5 * -9.8 * t)
        // u = (10 - (0.5 * -9.8 * t)) / t
        velocityY = (s - (0.5f * -9.8f * t)) / t;
        Debug.Log("y velocity: " + velocityY);

        // YOINK IT

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
    }
}



