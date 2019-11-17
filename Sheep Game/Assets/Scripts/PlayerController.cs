using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public Animator animator;
    public Text woolCountDisplay;
    public int woolCount; //Wool gained each level
    public int woolTotal; //Total wool that you add woolGained, wool that you spend 
    public int score; //Final score shown at end of game


    public int totalFiredBullets;
    public int missedBullets;

    public float totalDamageTaken;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Getting user input 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    
        if ((vertical == 0) && (horizontal == 0))
        {
            animator.SetBool("Moving", false) ;
        }
        else
        {
            animator.SetBool("Moving", true);
        }

        // Player Movement
        Vector2 position = rb2d.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        

        rb2d.MovePosition(position);

        // woolCountDisplay.text = "Wool Count: " + woolCount.ToString();
        
    }

}
