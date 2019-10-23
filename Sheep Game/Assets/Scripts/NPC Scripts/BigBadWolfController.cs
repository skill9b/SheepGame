﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadWolfController : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector3 initPosition;

    bool canBlow = true;
    bool isBlowing = false;
    float blowingCountdown;
    public float blowingCooldown;
    float storedCountdown;
    float storedCooldown;

    GameObject[] sheepInstances;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initPosition = transform.position;

        blowingCountdown = 0.5f;
        storedCountdown = blowingCountdown;
        storedCooldown = blowingCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (canBlow == true) && (isBlowing == false))
        {
            canBlow = false;
            isBlowing = true;
        }

        if (canBlow == false && isBlowing == true)
        {
            // Move all sheep instances back a few steps
            sheepInstances = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject sheep in sheepInstances)
            {
                sheep.transform.position += new Vector3(0.2f,0,0);
            }

            blowingCountdown -= Time.deltaTime;
        }

        if (blowingCountdown <= 0)
        {
            blowingCooldown -= Time.deltaTime;
            canBlow = false;
            isBlowing = false;
        }

        if (blowingCooldown <= 0)
        {
            blowingCountdown = storedCountdown;
            blowingCooldown = storedCooldown;
            canBlow = true;
            isBlowing = false;
        }

    }
}
