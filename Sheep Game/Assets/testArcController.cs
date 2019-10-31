using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testArcController : MonoBehaviour
{
    public Camera camera;
    public GameObject bulletObject;
    Vector3 mousePosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            bulletObject.GetComponent<testArcBulletController>().xDistance = Mathf.Abs(transform.position.x - mousePosition.x);
            Instantiate(bulletObject, transform.position, transform.rotation);
        }
    }
}
