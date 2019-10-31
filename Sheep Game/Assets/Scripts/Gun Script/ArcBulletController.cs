using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBulletController : MonoBehaviour
{
    public int damage;
    public Camera MainCamera;

    public float ColX = 0.2f, ColY = 0.2f;
    private BoxCollider2D AOE;

    private Rigidbody2D body;
    private Vector3 mousePosition;

    private float q = 0.25f;
    private float w = -0.25f;

    private bool gay = false;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        AOE = GetComponent<BoxCollider2D>();
        AOE.size = new Vector2(ColX, ColY);
    }

    private void Update()
    {
        if ((GetComponent<Rigidbody2D>().velocity.y < q) && (GetComponent<Rigidbody2D>().velocity.y > w))
        {
            Debug.Log("Is this wack:" + mousePosition);
            float a = GetComponent<Rigidbody2D>().transform.position.y - mousePosition.y;
            float o = GetComponent<Rigidbody2D>().transform.position.x - mousePosition.x;
            float omega = o / a;
            float theta = Mathf.Atan(omega);
            theta = theta * (180.0f / 3.14159f);

            transform.Rotate(0, 0, theta, Space.Self);

            q = 10f;
            w = 0f;
            gay = true;
            
        }

        if (gay == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            }

            transform.position = Vector2.MoveTowards(transform.position, mousePosition, 2f);

            Vector3 mouse = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            Debug.Log("mouse:" + mouse);
            Vector3 pos = transform.position;
            float xdiff = mouse.x - pos.x;
            float ydiff = mouse.y - pos.y;

            if ((xdiff == 0) && (ydiff == 0))
            {
                gay = false;
                Debug.Log(gay);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            if (transform.position.y < 10)
            {
                other.GetComponent<ParentSheepController>().TakeDamage(damage);
                //Add Code to instantiate animation and then only destroy the bullet
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }


}
