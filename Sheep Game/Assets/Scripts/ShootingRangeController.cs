using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // NPCHumptyDumptyController hd = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
            // hd.Fire();

            TurretController turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<TurretController>();
            turret.Fire(other.transform.position);
            Debug.Log(other.transform.position);
        } 
    }
}
