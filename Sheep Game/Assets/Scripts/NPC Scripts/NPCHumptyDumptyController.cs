using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHumptyDumptyController : MonoBehaviour
{
    public GameObject eggPrefab;
    public bool isEnemy;
    public bool canFire;
    public float eggCountdown; // adjusted for Rate of fire
    float maxEggCountdown;
    public Vector3 sheepTarget;

    // Suicide cooldown variables
    public float yeetSpeed;
    float nextYeetTime;
    public float fireRate;
    public Transform shootingPoint;
    public float cooldown;
    float maxCooldown;
    bool isCoolingDown;
    public GameObject cooldownObject;
    public ProgressBarCircle cooldownBar;
    public Transform topLeft;
    public Transform bottomRight;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        nextYeetTime = 0f;

        maxCooldown = cooldown;
        cooldownBar.BarValue = 100;
        cooldownObject.SetActive(false);

        isEnemy = false;
        canFire = true;
        maxEggCountdown = eggCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            YeetTheEgghead();
        }

        if (isCoolingDown)
        {
            cooldown -= Time.deltaTime;
            cooldownObject.SetActive(true);
            cooldownBar.BarValue = cooldownBar.BarValue - (100 / (maxCooldown / Time.deltaTime));
            if (cooldown <= 0)
            {
                Debug.Log("Cooldown finished.");
                gameObject.GetComponent<Renderer>().enabled = true;
                transform.position = originalPosition;
                cooldown = maxCooldown;
                isCoolingDown = false;

                cooldownBar.BarValue = 100;
                cooldownObject.SetActive(false);
            }
        }

        if (isEnemy)
        {
            if (canFire == true)
            {
                Fire(sheepTarget);
                canFire = false;
            }

            if (canFire == false)
            {
                eggCountdown -= Time.deltaTime;
                if (eggCountdown <= 0)
                {
                    eggCountdown = maxEggCountdown;
                    canFire = true;
                }
            }
        }

    }

    public void Fire(Vector3 _target)
    {
        // Set the target distance for egg
        eggPrefab.GetComponent<EggBulletController>().xDistance = Mathf.Abs(transform.position.x - _target.x);
        Instantiate(eggPrefab, transform.position, transform.rotation);
    }

    // Suicide function
    void YeetTheEgghead()
    {
        Vector3 target = new Vector3(Random.Range(topLeft.position.x, bottomRight.position.x), Random.Range(bottomRight.position.y, topLeft.position.y), transform.position.z);

        Vector3 difference = target - transform.position;

        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Time.time > fireRate + nextYeetTime)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            GetComponent<Rigidbody2D>().velocity = direction * yeetSpeed;

            nextYeetTime = Time.time;
        }
    }

    void RespawnHumptyDumpty()
    {
        isCoolingDown = true;
        Debug.Log("Cooling down now!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().TakeDamage(100);
            RespawnHumptyDumpty();
            gameObject.GetComponent<Renderer>().enabled = false;
        }

        if (other.tag == "Floor")
        {
            RespawnHumptyDumpty();
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}