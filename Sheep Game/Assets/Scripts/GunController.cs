using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Gun;
    public Camera camera;

    [SerializeField] float Speed = 4;
    [SerializeField] float Offset = 0;
    [SerializeField] float FireRate = 1;
    [SerializeField] int Cooldown = 0;
    private int BulletCount = 0; 

    private Vector3 Target;
    private float LastShot = 0;

    // Update is called once per frame
    void Update()
    {
        Target = camera.ScreenToWorldPoint(new Vector3(transform.position.x, (-Input.mousePosition.y) + Offset, transform.position.z));

        Vector3 difference = Target - Gun.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Gun.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();


            Fire(direction, rotationZ);

        }
    }

    IEnumerator Wait(int Seconds)
    {
        yield return new WaitForSeconds(Seconds);
    }

    void Fire(Vector2 direction, float rotationZ)
    {
       if (Time.time > FireRate + LastShot)
        {
            GameObject b = Instantiate(Bullet) as GameObject;
            b.transform.position = Gun.transform.position;
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = -direction * Speed;

            BulletCount += 1;

            LastShot = Time.time;
        }

        if (BulletCount == Cooldown)
        {
            
        }
    }
}