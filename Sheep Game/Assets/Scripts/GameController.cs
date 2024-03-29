﻿using System.Collections;
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

    public GameObject Base;
    public GameObject ArcGun;
    public GameObject LongGun;
    public GameObject ShotGun;
    public GameObject HumptyDumpty;
    public GameObject Wolf;
    public Level currentlevel;
    public Level nextLevel;
    public int checkWin;
    public bool goToNextLevel;
    public bool isUpgradeUIActive;

    public int healthMultiplyer;

    public int WoolCount;
    public int bulletsFired;
    public int bulletsMissed;

    public float healthLost;

    /////////////////////////////// FUNCTIONS ///////////////

    void Start()
    {
        Application.targetFrameRate = 30;
        isUpgradeUIActive = false;
        UpgradeUI.SetActive(false);
        DeactivateAllLevels();
        goToNextLevel = false;
        ChangeLevel(1);
        nextLevel = currentlevel + 1;
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

            // Disable wolf blowing
            Wolf.GetComponent<BigBadWolfController>().bUpgradesMenuActive = true;
            HumptyDumpty.GetComponent<NPCHumptyDumptyController>().bUpgradesMenuActive = true;

            CalculateWool();
            DeactivateAllLevels();
            DisableGunShooting();
            UpgradeUI.SetActive(true);
            isUpgradeUIActive = true;
            // if press Finish button then go to next level
            if (goToNextLevel) //When finish is pressed
            {
                // Reset Humpty Dumpty
                HumptyDumpty.GetComponent<Renderer>().enabled = true;
                HumptyDumpty.GetComponent<NPCHumptyDumptyController>().bUpgradesMenuActive = false;
                HumptyDumpty.GetComponent<NPCHumptyDumptyController>().canYeet = true;
                HumptyDumpty.GetComponent<NPCHumptyDumptyController>().isDead = false;
                HumptyDumpty.GetComponent<NPCHumptyDumptyController>().GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                HumptyDumpty.GetComponent<NPCHumptyDumptyController>().GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                HumptyDumpty.GetComponent<NPCHumptyDumptyController>().body.constraints = RigidbodyConstraints2D.None;



                // Reset Big Bad Wolf
                Wolf.GetComponent<BigBadWolfController>().bUpgradesMenuActive = false;

                // Reset Base 
                Base.GetComponent<BaseController>().currentHealth = Base.GetComponent<BaseController>().maxHealth;


                EnableGunShooting();
                UpgradeUI.SetActive(false);
                isUpgradeUIActive = false;
                currentlevel = nextLevel;
                ChangeNextLevel( (int)nextLevel + 1);
                goToNextLevel = false;
            }

        }

        if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().currentHealth <= 0)
        {
            GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().LoseScreen();
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
                    GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().WinScreen();
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

        healthMultiplyer = (int)(2 - (healthLost * 0.05));

        if ( healthMultiplyer > 0)
        {
            WoolCount = WoolCount * healthMultiplyer;
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score += WoolCount;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolTotal += WoolCount;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalFiredBullets = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().missedBullets = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().totalDamageTaken = 0;
    }
}
