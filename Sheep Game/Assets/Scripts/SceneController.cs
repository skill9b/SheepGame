using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int WoolCount;
    public int bulletsFired;
    public int bulletsMissed;

    public float healthLost;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)  // If currently on tutorial scene
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartGame();
            }
        }

    }

    public void ShowTutorial()
    {
        SceneManager.LoadScene(7);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void CalculateWool()
    {
        WoolCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount;
        bulletsFired = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalFiredBullets;
        bulletsMissed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().missedBullets;
        healthLost = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalDamageTaken;

        WoolCount = WoolCount * (1 + (1 - bulletsMissed / bulletsFired));// * (2 - (float(healthLost * 0.05f)));
        WoolCount = WoolCount * (2 - (int)(healthLost * 0.05));

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score += WoolCount;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolTotal += WoolCount;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalFiredBullets = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().missedBullets = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalDamageTaken = 0;
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene(8);
    }

}



//private static int gamelvl; //At the end of the level you need to pass this the level number using getactive().buildindex
//private static int replay = 1; //At the start of the level if gamelvl != buildindex, reset replay

//public static void LoadScene(int lvl)
//{
//    SceneManager.LoadScene(lvl);

//    DontDestroyOnLoad(this.gameObject);
//}

//public static void ReplayLvl()
//{
//    if (replay > 0)
//    {
//        replay--;
//        SceneManager.LoadScene(gamelvl);
//        DontDestroyOnLoad(this.gameObject);
//    }
//    else if (replay == 0)
//    {
//        SceneManager.LoadScene(0);
//    }
//}