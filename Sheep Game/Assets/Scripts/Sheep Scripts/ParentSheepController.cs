using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSheepController : MonoBehaviour
{
    public int health;
    public float speed;
    public int distanceFromEnemy;
    public int woolPoints;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // Stop if certain distance from enemy
        if (Vector2.Distance(transform.position, target.position) > distanceFromEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {

    }
}
