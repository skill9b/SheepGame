using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAoeController : MonoBehaviour
{
    public int damage;
    public float lifespan;

    void Update()
    {
        // destroy after a countdown
        if (lifespan >= 0)
        {
            lifespan -= Time.deltaTime;
            if (lifespan <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().TakeDamage(damage);
        }
    }
}
