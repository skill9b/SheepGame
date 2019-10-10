using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSheepController : ParentSheepController
{

    public Transform tinySheepObject;

    public override void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Play death sound
        // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddWool(woolPoints);

        Instantiate(tinySheepObject, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
}
