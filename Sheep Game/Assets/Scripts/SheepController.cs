using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public float speed;
    public int distanceFromEnemy;
    public int Health = 3;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceFromEnemy = 1;
        speed = 5.0f;
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > distanceFromEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hi");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 1;

            Destroy(collision.gameObject);

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
