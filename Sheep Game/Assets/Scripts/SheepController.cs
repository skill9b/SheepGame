using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public float speed;
    public int distanceFromEnemy;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceFromEnemy = 1;
        speed = 1.0f;
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > distanceFromEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
