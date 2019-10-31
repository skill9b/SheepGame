using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadWolfController : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector3 initPosition;

    bool canBlow = true;
    public bool isBlowing = false;
    public float blowingCountdown;
    public float blowingCooldown;
    float storedCountdown;
    float storedCooldown;
    

    public GameObject cooldownObject;
    public ProgressBarCircle cooldownBar;

    GameObject[] sheepInstances;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initPosition = transform.position;

        storedCountdown = blowingCountdown;
        storedCooldown = blowingCooldown;

        cooldownObject.SetActive(false);
        cooldownBar.BarValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (canBlow == true) && (isBlowing == false))
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
                sheep.transform.position += new Vector3(0.1f,0,0);
            }

            blowingCountdown -= Time.deltaTime;
        }

        if (blowingCountdown <= 0)
        {
            cooldownObject.SetActive(true);
            cooldownBar.BarValue = cooldownBar.BarValue - (100 / (storedCooldown / Time.deltaTime));

            blowingCooldown -= Time.deltaTime;
            canBlow = false;
            isBlowing = false;
        }

        if (blowingCooldown <= 0)
        {
            blowingCountdown = storedCountdown;
            blowingCooldown = storedCooldown;
            canBlow = true;
            isBlowing = false;

            cooldownObject.SetActive(false);
            cooldownBar.BarValue = 100;
        }

    }
}
