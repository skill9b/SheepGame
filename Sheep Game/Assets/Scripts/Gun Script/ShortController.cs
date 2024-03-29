﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortController : MonoBehaviour
{
    public AudioSource ShotgunShot;

    public bool bCanFire = true;

    public GameObject Bullet;
    public GameObject Gun;
    public Camera MainCamera;

    public float SpeedController = 100;
    public float Offset = 0;
    public float FireRate = 1;
    public int Mag = 5;
    public float CooldowntimeFull = 5f;
    public int CooldowntimeNotFull = 2;
    private int BulletCount = 0;

    public float Damage = 1;
    public float YScale = 2.5f;

    private Vector3 Target;
    private float LastShot = 0;
    private float Speed;

    public bool GunStats;

    private void Start()
    {
        ShotgunShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Target = MainCamera.ScreenToWorldPoint(new Vector3(transform.position.x, (-Input.mousePosition.y) + Offset, transform.position.z));

        Vector3 difference = Target - Gun.transform.position;

        if ((GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().isUpgradeUIActive))
        {
            ShotgunShot.Stop();
        }

        if (bCanFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();


                if (Input.mousePosition.x == 0)
                {
                    Speed = 0;
                }
                else
                {
                    Speed = Input.mousePosition.x / SpeedController;
                }

                Fire(direction, Speed);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalFiredBullets++;
            }
        }
        
    }

    //WaitForSecond returns a IEnumerator type, which is why it's it's own function
    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);   //Scaled time (No Idea what that means)
        BulletCount -= 1;   //The cooldown reduces bulletcount by 1
    }

    void Fire(Vector2 direction, float Speed)
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
                ShotgunShot.Play(0);
                
                GameObject b = Instantiate(Bullet) as GameObject;
                b.transform.position = Gun.transform.position;
                b.transform.position += Vector3.right * 1.8f; 
                b.GetComponent<Rigidbody2D>().velocity = -direction * Speed;

                BulletCount += 1;

                if (Time.time > CooldowntimeNotFull + LastShot) //Reduce the "Heat" cool down by a bit everytime the player doesn't shoot"
                {
                    if (BulletCount != 0)
                    {
                        BulletCount -= 1;
                    }
                }

                LastShot = Time.time;
                // Debug.Log("ShotGun Bullet Count:" + BulletCount);
            }
        }
    }
}