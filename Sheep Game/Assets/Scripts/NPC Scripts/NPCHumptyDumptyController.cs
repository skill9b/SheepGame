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
    public Animator animator;

    // Suicide cooldown variables
    public float yeetSpeed;
    float nextYeetTime;
    public float fireRate;
    public Transform shootingPoint;
    public float cooldown;
    public bool enableSuicide;
    public GameObject cooldownObject;
    public ProgressBarCircle cooldownBar;
    Vector3 target;
    public Transform suicideTarget;

    // Start is called before the first frame update
    void Start()
    {
        enableSuicide = false;

        nextYeetTime = 0f;

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
        if (enableSuicide)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Play flying
                animator.SetBool("Flying", true);
                YeetTheEgghead();
            }
        }

        if (isEnemy)
        {
            if (canFire == true)
            {
                //Play Shoot
                Fire(sheepTarget);
                canFire = false;
                //End Shoot
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
            //Play Explosion/Impact
            gameObject.GetComponent<Renderer>().enabled = false;

            GameObject[] allSheep = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject sheep in allSheep)
            {
               sheep.GetComponent<ParentSheepController>().TakeDamage(3);
            }
        }
    }
}