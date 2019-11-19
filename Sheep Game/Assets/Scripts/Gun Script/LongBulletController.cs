using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBulletController : MonoBehaviour
{
    public GameObject gun;
    private float damage;
    private int PassEnemies;

    private void Start()
    {
        damage = GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage;
        PassEnemies = GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().PassEnemies;
    }

    private void Update()
    {
        if ((transform.position.x > 0) || (GameObject.FindGameObjectWithTag("Player").GetComponent<GunSwitching>().longGunCheck))
        {
            GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().SoundCut = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().TakeDamage(damage);

            if (PassEnemies <= 0)
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<GunSwitching>().longGunCheck)
                {
                    GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().SheepImpact = true;
                }
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
