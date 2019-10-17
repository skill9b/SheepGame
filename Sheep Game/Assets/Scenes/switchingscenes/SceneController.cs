using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene(0);
            DontDestroyOnLoad(this.gameObject);
        }

        if (Input.GetKeyDown("s"))
        {
            SceneManager.LoadScene(1);
            DontDestroyOnLoad(this.gameObject);
        }

        if (Input.GetKeyDown("d"))
        {
            SceneManager.LoadScene(2);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
