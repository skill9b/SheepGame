using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortBulletController1 : MonoBehaviour
{
    // public GameObject Sheep;

    [SerializeField] float Seconds = 1;
    [SerializeField] int Mag = 6;
    
    private int EnemyCount = 0;
    private int Damage = 0;

    bool canFire = false;

    //IEnumerator Wait(float Seconds)
    //{
    //    yield return new WaitForSecondsRealtime(Seconds);   // Scaled time (No Idea what that means)
    //    Destroy(gameObject);
    //}

    private void Start()
    {

    }

    private void Update()
    {
        //StartCoroutine(Wait(Seconds));

        if (EnemyCount == 0)
        {
            canFire = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyCount++;
            Debug.Log(other + "entered!");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            canFire = true;
        }

        if (Input.GetMouseButtonDown(0) && canFire == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<ParentSheepController>().TakeDamage(Damage);
                Debug.Log(other + "took damage!");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyCount--;
            Debug.Log(other + "exited!");
        }
    }
}
