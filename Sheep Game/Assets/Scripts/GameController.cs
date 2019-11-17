using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    ///////////////////////////////// VARIABLES ///////////////
    public enum Level
    {
        Inbetween,
        One,
        Two,
        Three,
        Four,
        Five,
        Six
    }

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;
    public GameObject UpgradeUI;

    public GameObject ArcGun;
    public GameObject LongGun;
    public GameObject ShotGun;

    public Level currentlevel;
    public Level nextLevel;
    public int checkWin;
    public bool goToNextLevel;





    public int WoolCount;
    public int bulletsFired;
    public int bulletsMissed;

    public float healthLost;

    /////////////////////////////// FUNCTIONS ///////////////

    void Start()
    {

        UpgradeUI.SetActive(false);
        DeactivateAllLevels();
        goToNextLevel = false;
        ChangeLevel(1);
        //nextLevel = currentlevel + 1;
        //checkWin = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentlevel != Level.Inbetween)
        {
            ActivateLevel((int)currentlevel);
        }
        else if (currentlevel == Level.Inbetween)
        {
            CalculateWool();
            DeactivateAllLevels();
            DisableGunShooting();
            UpgradeUI.SetActive(true);
            // if press Finish button then go to next level
            if (goToNextLevel)
            {
                EnableGunShooting();
                UpgradeUI.SetActive(false);
                ChangeNextLevel( ((int)currentlevel) + 1 );
                goToNextLevel = false;
            }

        }

        if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().currentHealth <= 0)
        {
            //GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().LoseScreen();
        }

    }

    void ChangeNextLevel(int _nextLevel)
    {
        switch (_nextLevel)
        {
            case 0:
                {
                    nextLevel = Level.Inbetween;
                    break;
                }
            case 1:
                {
                    nextLevel = Level.One;
                    break;
                }
            case 2:
                {
                    nextLevel = Level.Two;
                    break;
                }
            case 3:
                {
                    nextLevel = Level.Three;
                    break;
                }
            case 4:
                {
                    nextLevel = Level.Four;
                    break;
                }
            case 5:
                {
                    nextLevel = Level.Five;
                    break;
                }
            case 6:
                {
                    nextLevel = Level.Six;
                    break;
                }
            case 7:
                {
                    //Go to win screen
                    //GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().LoseScreen();
                    break;
                }
        }
        
    }

    void DeactivateAllLevels()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Level4.SetActive(false);
        Level5.SetActive(false);
        Level6.SetActive(false);
    }

    void ChangeLevel(int _levelToActivate)
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Level4.SetActive(false);
        Level5.SetActive(false);
        Level6.SetActive(false);
        
        if (_levelToActivate == 1)
        {
            Level1.SetActive(true);
        }
        else if (_levelToActivate == 2)
        {
            Level2.SetActive(true);
        }
        else if (_levelToActivate == 3)
        {
            Level3.SetActive(true);
        }
        else if (_levelToActivate == 4)
        {
            Level4.SetActive(true);
        }
        else if (_levelToActivate == 5)
        {
            Level5.SetActive(true);
        }
        else if (_levelToActivate == 6)
        {
            Level6.SetActive(true);
        }
    }

    void ActivateLevel(int _levelToActivate)
    {
        if (_levelToActivate == 1)
        {
            Level1.SetActive(true);
        }
        else if (_levelToActivate == 2)
        {
            Level2.SetActive(true);
        }
        else if (_levelToActivate == 3)
        {
            Level3.SetActive(true);
        }
        else if (_levelToActivate == 4)
        {
            Level4.SetActive(true);
        }
        else if (_levelToActivate == 5)
        {
            Level5.SetActive(true);
        }
        else if (_levelToActivate == 6)
        {
            Level6.SetActive(true);
        }
    }

    void DisableGunShooting()
    {
        ArcGun.SetActive(true);
        LongGun.SetActive(true);
        ShotGun.SetActive(true);

        ArcGun.GetComponent<ArcController>().bCanFire = false;
        LongGun.GetComponent<LongController>().bCanFire = false;
        ShotGun.GetComponent<ShortController>().bCanFire = false;
    }

    void EnableGunShooting()
    {
        ArcGun.SetActive(false);
        LongGun.SetActive(true);
        ShotGun.SetActive(false);

        ArcGun.GetComponent<ArcController>().bCanFire = true;
        LongGun.GetComponent<LongController>().bCanFire = true;
        ShotGun.GetComponent<ShortController>().bCanFire = true;
    }

    public void PressFinish()
    {
        goToNextLevel = true;
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
}
