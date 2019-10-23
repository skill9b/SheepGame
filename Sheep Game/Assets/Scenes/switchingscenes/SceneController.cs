using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void LoadScene(int lvl)
    {
        SceneManager.LoadScene(lvl);
        DontDestroyOnLoad(this.gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
