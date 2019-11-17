using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcController : MonoBehaviour
{
    public bool bCanFire = true;

    public AudioSource DogShot;
    private bool bImpact;
 
    public GameObject Bullet;
    public GameObject Gun;
    public Camera mainCamera;

    // [SerializeField] float SpeedController = 100;
    public float Offset = 0;
    public float FireRate = 1;
    public int Mag = 5;
    public float CooldowntimeFull = 5f;
    public int CooldowntimeNotFull = 2;
    private int BulletCount = 0;

    public int Damage = 1;
   

    private Vector3 Target;
    public Vector2 MousePosition;
    private float LastShot = 0;
    private float Speed;

    public bool GunStats;

    private void Start()
    {
        DogShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Target = mainCamera.ScreenToWorldPoint(new Vector3(transform.position.x, (-Input.mousePosition.y) + Offset, transform.position.z));

        Vector3 difference = Target - Gun.transform.position;

        if (bCanFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();

                Speed = 10;
                MousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Fire(direction, Speed);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalFiredBullets++;
            }
        }


        bImpact = Bullet.GetComponent<ArcBulletController>().bImpact;
        if (bImpact)
        {
            if (DogShot.isPlaying)
            {
                DogShot.Stop();
            }
        }
    }

    //WaitForSecond returns a IEnumerator type, which is why it's it's own function
    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);   //Scaled time (No Idea what that means)
        BulletCount -= 1;   //The cooldown reduces bulletcount by 1
    }

    void Fire(Vector2 direction, float Speed)
    {
        DogShot.Play(0);

        if (Time.time > FireRate + LastShot)
        {
            if (BulletCount == Mag) //if the mag has been used up make player wait long
            {
                StartCoroutine(Wait(CooldowntimeFull));
            }

            //Regular Shooting
            if (BulletCount != Mag)
            {
                GameObject b = Instantiate(Bullet) as GameObject;
                b.GetComponent<ArcBulletController>().xDistance = Mathf.Abs(transform.position.x - MousePosition.x);
                b.transform.position = Gun.transform.position;
               // b.GetComponent<Rigidbody2D>().velocity = -direction * Speed;

                BulletCount += 1;

                if (Time.time > CooldowntimeNotFull + LastShot) //Reduce the "Heat" cool down by a bit everytime the player doesn't shoot"
                {
                    if (BulletCount != 0)
                    {
                        BulletCount -= 1;
                    }
                }

                LastShot = Time.time;

                // Debug.Log("ArcGun Bullet Count:" + BulletCount);
            }
        }
    }
}