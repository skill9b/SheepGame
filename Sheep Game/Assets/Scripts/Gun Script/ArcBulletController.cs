using System.Collections;
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
        Debug.Log("x velocity: " + velocityX);


        // Calculate init y velocity
        // s = ut + (0.5 * a * t^2)
        // 10 = u * t + (0.5 * -9.8 * t)
        // u = (10 - (0.5 * -9.8 * t)) / t
        velocityY = (s - (0.5f * -9.8f * t)) / t;
        Debug.Log("y velocity: " + velocityY);

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
    }

    private void Update()
    {
        //if ((GetComponent<Rigidbody2D>().velocity.y < 0.25) && (GetComponent<Rigidbody2D>().velocity.y > -0.25))
        //{
            //float a = GetComponent<Rigidbody2D>().transform.position.y - MousePosition.y;
            //float o = GetComponent<Rigidbody2D>().transform.position.x - MousePosition.x;
            //float omega = o / a;
            //float theta = Mathf.Atan(omega);
            //theta = theta * (180.0f / 3.14159f);

            //acceleration.x = a;
            //acceleration.y = o;

            //transform.Rotate(0, 0, theta, Space.Self);
            //GetComponent<Rigidbody2D>().velocity = acceleration * 10;
            
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inLaneState)
        {
            Debug.Log("T: " + other.gameObject.tag);
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
}
