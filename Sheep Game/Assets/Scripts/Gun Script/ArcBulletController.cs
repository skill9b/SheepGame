using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBulletController : MonoBehaviour
{

    public int damage;

    public float ColX = 0.2f, ColY = 0.2f;
    private BoxCollider2D AOE;

    private void Start()
    {
        AOE = GetComponent<BoxCollider2D>();
        AOE.size = new Vector2(ColX, ColY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            if (transform.position.y < 10)
            {
                other.GetComponent<ParentSheepController>().TakeDamage(damage);
                //Add Code to instantiate animation and then only destroy the bullet
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
