using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    enum State
    {
        Moving,
        Attacking,
        Idle
    };


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<SimpleHealthBar>().UpdateBar(currentHealth, maxHealth);

        // Debug.Log("currentHealth:" + currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().currentState = (ParentSheepController.State)State.Attacking;
            
        }

        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            other.GetComponent<ParentSheepController>().currentState = (ParentSheepController.State)State.Attacking;
        }
    }
}
