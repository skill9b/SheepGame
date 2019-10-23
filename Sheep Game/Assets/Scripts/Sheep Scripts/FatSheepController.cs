using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatSheepController : ParentSheepController
{

    public Transform tinySheepObject;

    public override void Die()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().woolCount += woolPoints;
        GameObject.FindWithTag("SpawnManager").GetComponent<SpawningController>().deadSheep += 1;

        Vector3 sheep1pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 sheep2pos = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
        Vector3 sheep3pos = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
        Vector3 sheep4pos;
        Vector3 sheep5pos;

        if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("SpawnPointTop").transform.position.y) < 1)
        { // Spawn two sheep above if Fat sheep against top of fence
            sheep4pos = new Vector3(transform.position.x + 0.7f, transform.position.y - 0.7f, transform.position.z + 1);
            sheep5pos = new Vector3(transform.position.x - 0.7f, transform.position.y - 0.7f, transform.position.z + 1);
        }
        else if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("SpawnPointBottom").transform.position.y) < 1)
        {   // Spawn two sheep below if Fat sheep against bottom of fence
            sheep4pos = new Vector3(transform.position.x + 0.7f, transform.position.y + 0.7f, transform.position.z + 1);
            sheep5pos = new Vector3(transform.position.x - 0.7f, transform.position.y + 0.7f, transform.position.z + 1);
        }
        else
        {
            sheep4pos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z + 1);
            sheep5pos = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z - 1);
        }

        if (Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("Base").transform.position.x) < 1)
        {

        }

        Instantiate(tinySheepObject, sheep1pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep2pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep3pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep4pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep5pos, Quaternion.identity);

        Destroy(gameObject);
    }
}
