using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumptyAoeController : MonoBehaviour
{
    public float lifespan;

    public Animator boomAnimator;

    private void Start()
    {
       transform.localScale = new Vector3(2.5f, 2.5f, 0f);
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
