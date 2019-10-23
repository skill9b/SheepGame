using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadWolfController : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector3 initPosition;

    bool canBlow = true;
    bool isBlowing = false;
    float blowingCountdown;
    float storedCountdown;
    public float blowingCooldown;

    GameObject[] sheepInstances;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initPosition = transform.position;

        storedCountdown = blowingCountdown;
        blowingCountdown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canBlow == true && isBlowing == false)
        {
            canBlow = false;
            isBlowing = true;
        }

        if (canBlow == false && isBlowing == true)
        {
            // Move all sheep instances back a few steps
            sheepInstances = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject sheep in sheepInstances)
            {
                sheep.transform.position += new Vector3(0.5f,0,0);
            }

            blowingCountdown -= Time.deltaTime;
        }

        if (blowingCountdown <= 0)
        {

            blowingCooldown -= Time.deltaTime;
            isBlowing = false;
        }

        if (blowingCooldown <= 0)
        {
            blowingCountdown = storedCountdown;
            canBlow = true;
        }

        // *** Reset countdown and cooldowns

    }
}
