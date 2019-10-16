using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public GameObject Base;
    public BaseController baseController;

    public float speed;
    public int distanceFromEnemy;
    public int health;
    public int woolPoints;
    private Vector2 target;
    private bool inRange = false; //In range for attacking
    public float attackSpeed;
    float nextShootTime;

    enum State
    {
        Moving, 
        Attacking,
        Idle
    };

    State currentState;

    void Start()
    {
        baseController = Base.GetComponent<BaseController>(); //Get script of base
        currentState = State.Moving;
        target = new Vector2 (transform.position.x - 1000, transform.position.y);
        distanceFromEnemy = 10;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                {
                    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //Set always to move left
                    break;
                }
                
            case State.Attacking:
                {
                    //Add timer so that sheep attack every 1.5s
                    if (Time.time > attackSpeed + nextShootTime)
                    {
                        baseController.health--;
                        Debug.Log(baseController.health);
                        nextShootTime = Time.time;
                    }
                    break;
                }
        }

        // Death
        if (health <= 0)
        {
            // Instantiate death animation
            // Instantiate dropping wool
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().woolCount += woolPoints;
            GameObject.FindWithTag("SpawnManager").GetComponent<SpawningController>().deadSheep += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base")
        {
            currentState = State.Attacking;
        }
    }

    public void TakeDamage(int _score)
    {
        health -= _score;
        Debug.Log("Taking damage!");
    }
}
