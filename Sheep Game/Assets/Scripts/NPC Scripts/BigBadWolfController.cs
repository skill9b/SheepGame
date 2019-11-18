using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadWolfController : MonoBehaviour
{
    AudioSource WolfBlow;
    Rigidbody2D rb2d;
    Vector3 initPosition;

    public bool bUpgradesMenuActive;

    public Animator animator;

    bool canBlow = true;
    public bool isBlowing = false;
    public float blowingCountdown;
    public float blowingCooldown;
    float storedCountdown;
    float storedCooldown;

    // public Animator animator;

    public GameObject cooldownObject;
    public ProgressBarCircle cooldownBar;

    GameObject[] sheepInstances;

    // Start is called before the first frame update
    void Start()
    {
        bUpgradesMenuActive = false;

        WolfBlow = GetComponent<AudioSource>();
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
        
        if (!bUpgradesMenuActive)
        {
            if (Input.GetKeyDown(KeyCode.Q) && (canBlow == true) && (isBlowing == false))
            {
                WolfBlow.Play(0);
                animator.SetTrigger("Blowing");
                canBlow = false;
                isBlowing = true;
                
            }

            if (canBlow == false && isBlowing == true)
            {
                //animator.SetBool("Idle", true);
                // Move all sheep instances back a few steps
                sheepInstances = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject sheep in sheepInstances)
                {
                    sheep.transform.position += new Vector3(0.1f, 0, 0);
                }
                animator.SetBool("Idle", true);
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
}
