using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    public GameObject Sheep;
    public SheepController SheepScript;

    [SerializeField] float Seconds = 1;
    [SerializeField] int Mag = 6;
    
    private int EnemyCount = 0;
    private int Damage = 0;

    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSecondsRealtime(Seconds);   //Scaled time (No Idea what that means)
        Destroy(gameObject);
    }

    private void Start()
    {
        SheepScript = Sheep.GetComponent<SheepController>();

    }

    private void Update()
    {
        StartCoroutine(Wait(Seconds));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyCount++;
          
            Damage = (Mag - EnemyCount) / EnemyCount;

            if (EnemyCount > Mag)
            {
                SheepScript.health -= 1;
            }

            if (EnemyCount < Mag)
            {
                SheepScript.health -= Damage;
            }

            Destroy(gameObject);
        }
    }
}
