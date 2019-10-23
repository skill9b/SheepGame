using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBulletController : MonoBehaviour
{

    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
