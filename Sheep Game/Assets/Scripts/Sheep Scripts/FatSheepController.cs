using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatSheepController : ParentSheepController
{

    public Transform tinySheepObject;

    public override void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Play death sound
        // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddWool(woolPoints);

        Vector3 sheep1pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 sheep2pos = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        Vector3 sheep3pos = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        Vector3 sheep4pos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z + 1);
        Vector3 sheep5pos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z - 1);

        Instantiate(tinySheepObject, sheep1pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep2pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep3pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep4pos, Quaternion.identity);
        Instantiate(tinySheepObject, sheep5pos, Quaternion.identity);

        Destroy(gameObject);
    }
}
