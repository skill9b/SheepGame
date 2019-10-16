﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHumptyDumptyController : MonoBehaviour
{
    float speed;
    public float yeetSpeed;

    public float fireRate;

    public GameObject bullet;
    public Transform shootingPoint;
    float nextShootTime;
    float nextYeetTime;
    Vector3 originalPosition; 

    public Transform topLeft;
    public Transform bottomRight;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        speed = Random.Range(5, 25);

        nextShootTime = 0f;
        nextYeetTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            YeetTheEgghead();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Shoot
        if ((other.tag == "Enemy"))
        {
            Vector3 target = new Vector3(Random.Range(topLeft.position.x, bottomRight.position.x), Random.Range(bottomRight.position.y, topLeft.position.y), transform.position.z);

            Vector3 difference = target - shootingPoint.transform.position;

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            shootingPoint.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            Fire(direction, rotationZ);
        }

    }

    void Fire(Vector2 direction, float rotationZ)
    {
        if (Time.time > fireRate + nextShootTime)
        {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = shootingPoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * speed;

            nextShootTime = Time.time;
        }
    }

    void YeetTheEgghead()
    {
        Vector3 target = new Vector3(Random.Range(topLeft.position.x, bottomRight.position.x), Random.Range(bottomRight.position.y, topLeft.position.y), transform.position.z);

        Vector3 difference = target - transform.position;

        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Time.time > fireRate + nextYeetTime)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            GetComponent<Rigidbody2D>().velocity = direction * yeetSpeed;

            nextYeetTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            other.GetComponent<SheepController>().TakeDamage(100);
        }

        if (other.tag == "Floor")
        {
            Instantiate(gameObject, originalPosition, Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }
    }
}