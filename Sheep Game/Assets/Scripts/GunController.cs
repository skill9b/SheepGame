﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;

    [SerializeField] float Speed = 4;
    private Vector3 Target;

    [SerializeField] float Offset = 0;

    // Update is called once per frame
    void Update()
    {
        Target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(transform.position.x, (-Input.mousePosition.y) + Offset, transform.position.z));

        Vector3 difference = Target - Player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Player.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Fire(direction, rotationZ);


        }
    }

    void Fire(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(Bullet) as GameObject;
        b.transform.position = Player.transform.position;
        b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = -direction * Speed;
    }
}