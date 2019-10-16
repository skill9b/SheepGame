using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;
    public float fireRate;
    public Transform shootingPoint;
    float nextShootTime;




    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Entered Range");
        }
        else
        {
            Debug.Log("Not enemy entered range");
        }
        //Set Target
        //Add to list?
        //Check distance, type of enenmy
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Shoot
        if ((other.tag == "Enemy"))
        {
            Vector3 Target = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z); //Gets position of target and stores in vector

            Vector3 difference = Target - shootingPoint.transform.position;

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            shootingPoint.transform.rotation = Quaternion.Euler(0, 0, rotationZ);


            Fire(direction, rotationZ);


            //  Instantiate(Bullet, shootingPoint.position, Quaternion.identity); //Create bullet at shooting point with no rotation using identity quaternion
        }
              

    }

    void Fire(Vector2 direction, float rotationZ)
    {
        if (Time.time > fireRate + nextShootTime)
        {
            GameObject b = Instantiate(Bullet) as GameObject;
            b.transform.position = shootingPoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * Speed;

            nextShootTime = Time.time;
        }
    }
}
