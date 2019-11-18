using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeController : MonoBehaviour
{
    public bool isEggDead;
    // Start is called before the first frame update
    void Start()
    {
        isEggDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (!isEggDead)
            {
                NPCHumptyDumptyController hd = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
                if (other.transform.position.x > -3.5f)
                {
                    hd.sheepTarget = other.transform.position - (new Vector3(3, 0, 0));
                }
                else
                {
                    hd.sheepTarget = other.transform.position;
                }
                hd.isEnemy = true;
            }
        }


    }
}
