using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private bool moving;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis ("Vertical");

        if (moveVertical != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        Vector2 movement = new Vector2(0, moveVertical);
        if (moving)
        {
            rb2d.AddForce(movement * speed);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

}
