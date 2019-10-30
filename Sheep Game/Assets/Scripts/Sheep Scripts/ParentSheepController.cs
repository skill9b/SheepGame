using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSheepController : MonoBehaviour
{
    public BaseController baseController;
    public Animator animator;
    public int health;
    public float speed;
    public int distanceFromEnemy;
    public int woolPoints;
    private Vector2 target;
    public float attackSpeed;
    float nextAttackTime;
    public float attackDamage;
    public Rigidbody2D body;
    bool IsIdle;
    public enum State
    {
        Moving,
        Attacking,
        Idle
    };

    public State currentState;

    void Start()
    {
        IsIdle = GameObject.FindWithTag("Wolf").GetComponent<BigBadWolfController>().isBlowing;
        baseController = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>(); //Get script of base
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
            case State.Idle:
                {
                    break;
                }
            case State.Attacking:
                {
                    //body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionX;
                    //body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionY;
                    //body.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezeRotation;

                    body.constraints = RigidbodyConstraints2D.FreezeAll | RigidbodyConstraints2D.FreezeAll;

                    animator.SetBool("Attacking", true);
                    
                    if (Time.time > nextAttackTime) 
                    {
                        baseController.currentHealth -= attackDamage;
                        Debug.Log(baseController.currentHealth);
                        nextAttackTime = Time.time + attackSpeed;
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
        else if (IsIdle)
        {
            currentState = State.Idle;
        }
        else
        {
            currentState = State.Moving;
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
