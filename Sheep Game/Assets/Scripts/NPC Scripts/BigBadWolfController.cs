using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadWolfController : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector3 initPosition;

    bool canBlow = true;
    bool isBlowing = false;
    public float blowingCountdown;
    public float blowingCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canBlow == true && isBlowing == false)
        {
            canBlow = false;
            isBlowing = true;
            initPosition += new Vector3(0, 1, 0);
            rb2d.MovePosition(initPosition);
            blowingCountdown -= 1;
        }

        if (blowingCountdown <= 0)
        {

            blowingCooldown -= 1;
            isBlowing = false;
        }

        if (blowingCooldown <= 0)
        {
            canBlow = true;
        }

    }
}
