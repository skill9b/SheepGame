using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHumptyDumptyController : MonoBehaviour
{
    public GameObject eggPrefab;
    public bool isEnemy;
    bool canFire;
    public bool bSpin = false;
    public float eggCountdown; // adjusted for Rate of fire
    float maxEggCountdown;
    public Vector3 sheepTarget;
    public Animator animator;

    public bool bUpgradesMenuActive;
    public Rigidbody2D body;
    public bool isDead;
    // Suicide cooldown variables
    public float yeetSpeed;
    float nextYeetTime;
    public float fireRate;
    public Transform shootingPoint;
    public float cooldown;
    public bool enableSuicide;
    Vector3 target;
    public Transform suicideTarget;
    public Vector3 startingPosition;
    public bool canYeet;
    // Start is called before the first frame update

    public GameObject AoeAnimObject;
    void Start()
    {
        bUpgradesMenuActive = false;

        startingPosition = transform.position;

        enableSuicide = false;
        isDead = false;

        isEnemy = false;
        canFire = true;
        maxEggCountdown = eggCountdown;
        canYeet = true;
        target = suicideTarget.position;

        // Ignore collisions between sheep and eggbullet layer
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableSuicide)
        {
            if (!bUpgradesMenuActive)
            {
                if (canYeet)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        animator.SetBool("Flying", true);


                        YeetTheEgghead();
                        isDead = true;
                        canYeet = false;
                    }
                }
            }
        }
        if (bSpin)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -10);
        }

        if (isEnemy)
        {
            if (!(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().isUpgradeUIActive))
            {
                if (canFire == true)
                {

                    //Play Shoot
                    animator.SetTrigger("Shooting");
                    if (!isDead)
                    {
                        Fire(sheepTarget);
                    }
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

        float rotationZ = -(Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg);
        //transform.position += new Vector3(0, 0.5f, 0);
        GetComponent<Rigidbody2D>().velocity += new Vector2(0, 1);
        transform.rotation = Quaternion.Euler(0, 0, -1 * rotationZ);

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        ///transform.position += new Vector3(0, 0.5f, 0);
        GetComponent<Rigidbody2D>().velocity = direction * yeetSpeed;
        bSpin = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "HumptyDumptyFloor") || (other.gameObject.tag == "Enemy"))
        {

            Instantiate(AoeAnimObject, transform.position, transform.rotation);
            //gameObject.GetComponent<Renderer>().enabled = false;

            GameObject[] allSheep = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject sheep in allSheep)
            {
                Debug.Log("Sheep took BIG damage!");
                sheep.GetComponent<ParentSheepController>().TakeDamage(100);
            }

            transform.position = startingPosition;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            bSpin = false;
            

        }
    }
}