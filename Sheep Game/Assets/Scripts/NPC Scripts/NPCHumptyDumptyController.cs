using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHumptyDumptyController : MonoBehaviour
{
    float speed;
    public float yeetSpeed;

    public float fireRate;

    public GameObject bullet;
    public Transform shootingPoint;
    float nextShootTime;
    float nextYeetTime;
    Vector3 originalPosition; 

    public Transform topLeft;
    public Transform bottomRight;

    float rotationZ;
    Vector2 direction;

    public float cooldown;
    float maxCooldown;
    bool isCoolingDown;
    public GameObject cooldownObject;
    public ProgressBarCircle cooldownBar;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        speed = Random.Range(5, 25);

        nextShootTime = 0f;
        nextYeetTime = 0f;

        maxCooldown = cooldown;
        cooldownBar.BarValue = 100;
        cooldownObject.SetActive(false);
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
            }
        }
        

    }


    public void Fire()
    {
        Vector3 target = new Vector3(Random.Range(topLeft.position.x, bottomRight.position.x), Random.Range(bottomRight.position.y, topLeft.position.y), transform.position.z);

        Vector3 difference = target - shootingPoint.transform.position;

        float distance = difference.magnitude;
        direction = difference / distance;
        direction.Normalize();

        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shootingPoint.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Time.time > fireRate + nextShootTime)
        {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = shootingPoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * speed;

            nextShootTime = Time.time;
        }
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

        if (other.tag == "Chimney")
        {
            // dont go thorugh
        }
    }
}