﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ArcBulletController : ArcController
{
    public int damage;

    public float ColX = 0.2f, ColY = 0.2f;
    private BoxCollider2D AOE;

    private Vector2 acceleration;

    public float xDistance;

    float velocityX;
    float velocityY;

    Vector2 STUPIDMOUSEPOSITION;

    private void Start()
    {
        AOE = GetComponent<BoxCollider2D>();
        AOE.size = new Vector2(ColX, ColY);

        float t = 1; //1;
        float s = 3; //3;

        xDistance = xDistance / 1.60f;

        // Calculate init x velocity
        // s = ut + (0.5 * a * t^2)
        // s = ut
        // u = s / t
        velocityX = xDistance / t;


        // Calculate init y velocity
        // s = ut + (0.5 * a * t^2)
        // 10 = u * t + (0.5 * -9.8 * t)
        // u = (10 - (0.5 * -9.8 * t)) / t
        velocityY = (s - (0.5f * -9.8f * t)) / t;

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            STUPIDMOUSEPOSITION = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("B: " + transform.position.y);
        Debug.Log("M: " + STUPIDMOUSEPOSITION.y);

        if (transform.position.y == STUPIDMOUSEPOSITION.y)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<ParentSheepController>().TakeDamage(damage);
                //Add Code to instantiate animation and then only destroy the bullet
                Destroy(gameObject);
            }
        }
    }
}
