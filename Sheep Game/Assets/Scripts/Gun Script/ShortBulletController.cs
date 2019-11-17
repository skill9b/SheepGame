using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortBulletController : MonoBehaviour
{
    public float Seconds;

    private float damage;
    private float YScale;

    private void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().Damage;
        YScale = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().YScale;

        transform.localScale += new Vector3(0, YScale, 0);
    }

    //WaitForSecond returns a IEnumerator type, which is why it's it's own function
    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);   //Scaled time (No Idea what that means)
        Destroy(gameObject);
    }

    private void Update()
    {
        StartCoroutine(Wait(Seconds));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.GetComponent<ParentSheepController>().currentState);
            other.GetComponent<ParentSheepController>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
