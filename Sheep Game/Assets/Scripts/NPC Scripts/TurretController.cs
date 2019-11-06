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

    public void Fire(Vector3 _target)
    {
        if (Time.time > fireRate + nextShootTime)
        {
            Vector3 difference = _target - shootingPoint.transform.position; //Difference is distance between the target (enemy) and shooting point in vector form

            //Calculate direction using distance
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            //Using direction convert distance to a rotation in degrees to be applied to gun and bullet
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            shootingPoint.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            //Create bullet with passed in direction and speed
            GameObject b = Instantiate(Bullet) as GameObject;
            b.transform.position = shootingPoint.transform.position; //Set position of bullet to shooting point position
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ); //Set rotation of bullet
            b.GetComponent<Rigidbody2D>().velocity = direction * Speed; //Set velocity based on set speed value and direction

            nextShootTime = Time.time;
        }
    }
}
