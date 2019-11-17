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

    public GameObject[] Levels;

    public Level currentlevel;
    public Level nextLevel;
    public int checkWin;


    /////////////////////////////// FUNCTIONS ///////////////
  
    void Start()
    {
        //DeactivateAllLevels();
        currentlevel = Level.One;
        nextLevel = currentlevel + 1;
        checkWin = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentlevel == Level.Inbetween)
        {
            DeactivateAllLevels();
            UpgradeUI.SetActive(true);
            //Disable all
            //Enable Upgrade
            //When finish is clicked start next level


            if (currentlevel == Level.Six)
            {
                //Go to win screen
            }
            
            //Do check for button here
              ///currentlevel = nextLevel;
              ///nextLevel++;
              ///         
        }

        if (currentlevel == Level.One) //&& (check == 0))
        {
            ChangeLevel(1);
            Debug.Log("Start Level One");
        }
        else if(currentlevel == Level.Two)
        {
            ChangeLevel(2);
        }
        else if (currentlevel == Level.Three)
        {
            ChangeLevel(3);
        }
        else if (currentlevel == Level.Four)
        {
            ChangeLevel(4);
        }
        else if (currentlevel == Level.Five)
        {
            ChangeLevel(5);
        }
        else if (currentlevel == Level.Six)
        {
            ChangeLevel(6);
        }

        if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().currentHealth == 0)
        {
            //Go to lose screen
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
}
