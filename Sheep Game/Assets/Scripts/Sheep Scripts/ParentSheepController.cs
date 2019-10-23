using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSheepController : MonoBehaviour
{
    public GameObject Base;
    public BaseController baseController;
    public Animator animator;
    public int health;
    public float speed;
    public int distanceFromEnemy;
    public int woolPoints;
    private Vector2 target;
    public float attackSpeed;
    float nextAttackTime;

    public enum State
    {
        Moving,
        Attacking,
        Idle
    };

    public State currentState;

    void Start()
    {
        baseController = Base.GetComponent<BaseController>(); //Get script of base
        currentState = State.Moving;
        target = new Vector2(transform.position.x - 1000, transform.position.y);
        distanceFromEnemy = 10;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                {
                    animator.SetBool("Attacking", false);
                    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //Set always to move left
                    break;
                }

            case State.Attacking:
                {
                    animator.SetBool("Attacking", true);
                    //Add timer so that sheep attack every 1.5s
                    if (Time.time > attackSpeed + nextAttackTime)
                    {
                        baseController.health--;
                        // Debug.Log(baseController.health);
                        nextAttackTime = Time.time;
                    }
                    break;
                }
        }

        // Death
        if (health <= 0)
        {
            // Instantiate(deathEffect, transform.position, Quaternion.identity);
            // drop wool
            // Play death sound
            Die();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            currentState = State.Attacking;
        }

        if (other.gameObject.tag == "ShootingRange")
        {
            TurretController turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<TurretController>();
            turret.Fire(other.transform.position);
        }
    }

    public void TakeDamage(int _score)
    {
        health -= _score;
    }

    public virtual void Die()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().woolCount += woolPoints;
        GameObject.FindWithTag("SpawnManager").GetComponent<SpawningController>().deadSheep += 1;
        Destroy(gameObject);
    }
}
