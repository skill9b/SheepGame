using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHumptyDumptyController : MonoBehaviour
{
    public GameObject eggPrefab;
    public bool isEnemy;
    bool canFire;
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
    Vector3 target;
    public Transform suicideTarget;
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

        target = suicideTarget.position;

        // Ignore collisions between sheep and eggbullet layer
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            YeetTheEgghead();
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
        eggPrefab.GetComponent<EggBulletController>().target = _target;

        //Transform eggBullet = Instantiate(eggPrefab) as Transform;
        //Physics.IgnoreCollision(eggBullet.GetComponent<Collider>(), GetComponent<Collider>());
        Instantiate(eggPrefab, transform.position, transform.rotation);
    }

    // Suicide function
    void YeetTheEgghead()
    {

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HumptyDumptyFloor" || other.tag == "Enemy")
        {
            gameObject.GetComponent<Renderer>().enabled = false;

            GameObject[] allSheep = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject sheep in allSheep)
            {
               sheep.GetComponent<ParentSheepController>().TakeDamage(3);
            }
        }
    }
}