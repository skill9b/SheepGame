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

    public Level currentlevel;
    public Level nextLevel;
    public int checkWin;
    public bool goToNextLevel;


    /////////////////////////////// FUNCTIONS ///////////////
  
    void Start()
    {
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

            DeactivateAllLevels();
            UpgradeUI.SetActive(true);
            // if press Finish button then go to next level
            if (goToNextLevel)
            {
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

    public void PressFinish()
    {
        goToNextLevel = true;
    }
}
