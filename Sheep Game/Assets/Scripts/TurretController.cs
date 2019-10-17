﻿using System.Collections;
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

    void OnTriggerEnter2D(Collider2D collision) //When sheep enter trigger box that acts as range of turret
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Entered Range");
        }
        else
        {
            Debug.Log("Not enemy entered range");
        }
    }

    private void OnTriggerStay2D(Collider2D other) //When sheep stay in range of turret
    {
        //Shoot if a enemy has entered range
        if ((other.tag == "Enemy"))
        {
            Debug.Log("Shoot");
            Vector3 Target = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z); //Gets position of target and stores in vector

            Vector3 difference = Target - shootingPoint.transform.position; //Difference is distance between the target (enemy) and shooting point in vector form

            //Calculate direction using distance
            float distance = difference.magnitude; 
            Vector2 direction = difference / distance;
            direction.Normalize();

            //Using direction convert distance to a rotation in degrees to be applied to gun and bullet
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            shootingPoint.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            Fire(direction, rotationZ);

        }
              

    }

    void Fire(Vector2 direction, float rotationZ)
    {
        if (Time.time > fireRate + nextShootTime)
        {
            //Create bullet with passed in direction and speed
            GameObject b = Instantiate(Bullet) as GameObject;
            b.transform.position = shootingPoint.transform.position; //Set position of bullet to shooting point position
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ); //Set rotation of bullet
            b.GetComponent<Rigidbody2D>().velocity = direction * Speed; //Set velocity based on set speed value and direction

            nextShootTime = Time.time;
        }
    }
}
