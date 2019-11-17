using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBulletController : LongController
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().TakeDamage(Damage);

            if (PassEnemies <= 0)
            {
                Destroy(gameObject);
            }

            PassEnemies--;

        }

        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
