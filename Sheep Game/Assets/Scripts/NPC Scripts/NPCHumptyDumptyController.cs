using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHumptyDumptyController : MonoBehaviour
{
    public GameObject eggPrefab;
    public bool isEnemy;
    public bool canFire;
    public bool bSpin;
    public float eggCountdown; // adjusted for Rate of fire
    float maxEggCountdown;
    public Vector3 sheepTarget;
    public Animator animator;

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
    // Start is called before the first frame update

    public GameObject AoeAnimObject;
    void Start()
    {
        startingPosition = transform.position;
        startingPosition -= new Vector3(1, 0, 0);
        startingPosition += new Vector3(1, 0, 0);

        enableSuicide = false;
        isDead = false;

        isEnemy = false;
        bSpin = false;
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
            animator.SetBool("Flying", true);
            YeetTheEgghead();
        }


        if (bSpin)
        {
            transform.rotation =  transform.rotation * Quaternion.Euler(0, 0, -10);
        }

        if (isEnemy)
        {
            if (!(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().isUpgradeUIActive))
            {
                if (canFire == true)
                {
                    //Play Shoot
                    animator.SetTrigger("Shooting");
                    Fire(sheepTarget);
                    canFire = false;
                    //End Shoot
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
        if (other.gameObject.tag == "HumptyDumptyFloor")
        {

            Instantiate(AoeAnimObject, transform.position, transform.rotation);
            gameObject.GetComponent<Renderer>().enabled = false;

            GameObject[] allSheep = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject sheep in allSheep)
            {
                Debug.Log("Sheep took BIG damage!");
                sheep.GetComponent<ParentSheepController>().TakeDamage(100);
            }

            transform.position = startingPosition;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            bSpin = false;
            canFire = false;
        }


        
    }
}