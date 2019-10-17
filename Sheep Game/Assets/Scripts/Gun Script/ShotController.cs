﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Gun;
    public Camera MainCamera;

    [SerializeField] float Speed = 4;
    [SerializeField] float Offset = 180;
    [SerializeField] float FireRate = 1;
    [SerializeField] int Mag = 5;
    [SerializeField] float CooldowntimeFull = 5f;
    [SerializeField] int CooldowntimeNotFull = 2;
    private int BulletCount = 0;

    private Vector3 Target;
    private float LastShot = 0;

    // Update is called once per frame
    void Update()
    {
        Target = MainCamera.ScreenToWorldPoint(new Vector3(transform.position.x, (-Input.mousePosition.y) + Offset, transform.position.z));

        Vector3 difference = Target - Gun.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Gun.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            Fire(direction, rotationZ);
        }
    }

    //WaitForSecond returns a IEnumerator type, which is why it's it's own function
    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);   //Scaled time (No Idea what that means)
        BulletCount -= 1;   //The cooldown reduces bulletcount by 1
    }

    void Fire(Vector2 direction, float rotationZ)
    {
        if (Time.time > FireRate + LastShot)
        {
            if (BulletCount == Mag) //if the mag has been used up make player wait long
            {
                StartCoroutine(Wait(CooldowntimeFull));
            }

            //Regular Shooting
            if (BulletCount != Mag)
            {
                GameObject a = Instantiate(Bullet) as GameObject;
                a.transform.position = Gun.transform.position;
                a.transform.rotation = Quaternion.Euler(0, 180, -rotationZ);
                a.GetComponent<Rigidbody2D>().velocity = direction * Speed;

                BulletCount += 1;

                if (Time.time > CooldowntimeNotFull + LastShot) //Reduce the "Heat" cool down by a bit everytime the player doesn't shoot"
                {
                    if (BulletCount != 0)
                    {
                        BulletCount -= 1;
                    }

                    {
                        Debug.Log("hi uwu");    //Adds ambience to code :)
                    }
                }

                LastShot = Time.time;
                Debug.Log(BulletCount);
            }
        }
    }
}