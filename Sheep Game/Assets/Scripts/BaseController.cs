using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float health;

    enum State
    {
        Moving,
        Attacking,
        Idle
    };


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(health);

    }

    // Update is called once per frame
    void Update()
    {
        
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



   //private void OnCollisionEnter2D(Collider2D other)
   //{
   //    if (other.gameObject.tag == "Enemy")
   //    {
   //        other.GetComponent<ParentSheepController>().currentState = (ParentSheepController.State)State.Attacking;
   //    }
   //}
}
