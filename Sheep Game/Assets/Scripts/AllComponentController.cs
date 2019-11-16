using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllComponentController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
