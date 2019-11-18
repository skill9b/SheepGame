using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAoeController : MonoBehaviour
{
    public int damage;
    public float lifespan;

    public Animator boomAnimator;

    public float blastRadius = 1.5f;

    private void Start()
    {
        transform.localScale = new Vector2(1.5f, 1.5f);
        OnAoEImpact();
    }

    void OnAoEImpact()
    {
        GameObject[] allSheep = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject sheep in allSheep)
        {
            if (blastRadius >= Vector2.Distance(transform.position, sheep.transform.position))
            {
                Debug.Log("Sheep took damage!");
                sheep.GetComponent<ParentSheepController>().TakeDamage(damage);
            }
        }
        
    }

    void Update()
    {
        // Destroy after a countdown
        if (lifespan >= 0)
        {
            lifespan -= Time.deltaTime;
            if (lifespan <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
