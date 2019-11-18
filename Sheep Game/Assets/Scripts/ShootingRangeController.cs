using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeController : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
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

