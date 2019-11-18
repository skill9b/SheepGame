using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBulletController : MonoBehaviour
{
    public Vector3 target;
    public float xDistance;
    public int damage;
    bool bShowAoE = false;

    public GameObject AoeObject;

    float velocityX;
    float velocityY;

    // Start is called before the first frame update
    void Start()
    {
        float t = 1;
        float s = 3;

        if (target.x >= -2.0)
        {

            // xDistance = (xDistance / 1.60f) - 1.2f;
            xDistance = (xDistance / 1.60f) - 1.0f;
        }
        else
        {
            xDistance = (xDistance / 1.60f) - 0.6f;
        }

        // Calculate init x velocity
        // s = ut + (0.5 * a * t^2)
        // s = ut
        // u = s / t
        velocityX = xDistance / t;
        // Debug.Log("x velocity: " + velocityX);

        // Calculate init y velocity
        // s = ut + (0.5 * a * t^2)
        // 10 = u * t + (0.5 * -9.8 * t)
        // u = (10 - (0.5 * -9.8 * t)) / t
        velocityY = (s - (0.5f * -9.8f * t)) / t;
        // Debug.Log("y velocity: " + velocityY);

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
    }

    void Update()
    {

        // if target reached, destroy game object and switch on AoE object attached
        if ((transform.position.x >= target.x))
        {
            bShowAoE = true;
        }

        if (bShowAoE)
        {
            CreateAoE();
        }
    }

    void CreateAoE()
    {
        AoeObject.GetComponent<EggAoeController>().damage = damage;
        Instantiate(AoeObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CreateAoE();
            Destroy(gameObject);

        }

        //if (other.gameObject.tag == "HumptyDumptyFloor")
        //{
        //    CreateAoE();
        //    Destroy(gameObject);
        //}
    }
}
