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
    public Transform fence;

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

        // If touching base, Attack (*** still needs cooldown implementation)
        if (Vector2.Distance(transform.position, fence.position) < 1)
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        // Attack base
        Debug.Log("Hit the fence!");
    }

    public virtual void Die()
    {

    }
}
