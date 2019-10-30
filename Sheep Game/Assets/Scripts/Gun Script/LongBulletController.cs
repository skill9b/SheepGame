using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBulletController : MonoBehaviour
{
    public int damage;
    public int PassEnemies = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().TakeDamage(damage);

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
