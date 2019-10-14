using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(health);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {
            Debug.Log(health);
            health--;
            Debug.Log(health);
        }
    }


}
