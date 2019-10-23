using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    public GameObject ArcGun;
    public GameObject LongGun;
    public GameObject ShortGun;

    private void Start()
    {
        ArcGun.SetActive(false);
        ShortGun.SetActive(false);

        LongGun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShortGun.SetActive(false);
            LongGun.SetActive(false);

            ArcGun.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShortGun.SetActive(false);
            ArcGun.SetActive(false);

            LongGun.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ArcGun.SetActive(false);
            LongGun.SetActive(false);

            ShortGun.SetActive(true);
        }
    }
}
