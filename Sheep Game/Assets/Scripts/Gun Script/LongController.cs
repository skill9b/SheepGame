using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LongController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Gun;
    public Camera MainCamera;

    [SerializeField] float Offset = 0;
    [SerializeField] float FireRate = 1;
    [SerializeField] int Mag = 5;
    [SerializeField] float CooldowntimeFull = 5f;
    [SerializeField] int CooldowntimeNotFull = 2;
    private int BulletCount = 0;

    private Vector3 Target;
    private float LastShot = 0;
    private float Speed = 40;

    public GameObject cooldownObject;
    public ProgressBarCircle cooldownBar;

    void Start()
    {
        //cooldownObject.SetActive(true); 
        //cooldownBar.BarValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Target = MainCamera.ScreenToWorldPoint(new Vector3(transform.position.x, (-Input.mousePosition.y) + Offset, transform.position.z));

        Vector3 difference = Target - Gun.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            //Unity has issues with high speed collisions, meaning that the speed cannot vary otherwise stuff will glitch out
            /*if (Input.mousePosition.x == 0)
            {
                Speed = 0;
            }
            else
            {
                Speed = Input.mousePosition.x / SpeedController;
            }*/

            Fire(direction, Speed);
        }
        //cooldownBar.BarValue = (BulletCount / Mag) * 100;

    }

    //WaitForSecond returns a IEnumerator type, which is why it's it's own function
    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);   //Scaled time (No Idea what that means)
        BulletCount -= 1;   //The cooldown reduces bulletcount by 1
    }

    void Fire(Vector2 direction, float Speed)
    {
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
                b.transform.position = Gun.transform.position;
                b.GetComponent<Rigidbody2D>().velocity = //-direction * Speed;
                b.GetComponent<Rigidbody2D>().velocity += Vector2.right * Speed;

                BulletCount += 1;

                if (Time.time > CooldowntimeNotFull + LastShot) //Reduce the "Heat" cool down by a bit everytime the player doesn't shoot"
                {
                    if (BulletCount != 0)
                    {
                        BulletCount -= 1;
                    }
                }

                LastShot = Time.time;
            }
        }
    }


}