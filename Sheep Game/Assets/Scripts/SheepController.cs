using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public float speed;
    public int distanceFromEnemy;
    public int Health = 3;
    private Vector2 target;

    void Start()
    {
        target = new Vector2 (transform.position.x - 1000, transform.position.y);
        distanceFromEnemy = 1;
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, target) > distanceFromEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //Set always to move left
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
