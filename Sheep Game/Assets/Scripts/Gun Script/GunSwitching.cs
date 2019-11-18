using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    public GameObject ArcGun; public Image Arc;
    public GameObject LongGun; public Image Long;
    public GameObject ShortGun; public Image Short;

    public bool longGunCheck;
    private void Start()
    {
        ArcGun.SetActive(false); Color Temp = Arc.color; Temp.a = 0.3f; Arc.color = Temp;
        ShortGun.SetActive(false); Temp = Short.color; Temp.a = 0.3f; Short.color = Temp;

        LongGun.SetActive(true); Temp = Long.color; Temp.a = 1.0f; Long.color = Temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShortGun.SetActive(false); Color Temp = Short.color; Temp.a = 0.3f; Short.color = Temp;
            LongGun.SetActive(false); Temp = Long.color; Temp.a = 0.3f; Long.color = Temp;
            longGunCheck = false;
            ArcGun.SetActive(true); Temp = Arc.color; Temp.a = 1.0f; Arc.color = Temp;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShortGun.SetActive(false); Color Temp = Short.color; Temp.a = 0.3f; Short.color = Temp;
            ArcGun.SetActive(false); Temp = Arc.color; Temp.a = 0.3f; Arc.color = Temp;
            longGunCheck = true;
            LongGun.SetActive(true); Temp = Long.color; Temp.a = 1.0f; Long.color = Temp;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ArcGun.SetActive(false); Color Temp = Arc.color; Temp.a = 0.3f; Arc.color = Temp;
            LongGun.SetActive(false); Temp = Long.color; Temp.a = 0.3f; Long.color = Temp;
            longGunCheck = false;
            ShortGun.SetActive(true); Temp = Short.color; Temp.a = 1.0f; Short.color = Temp;
        }
    }
}
