﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//public static class SceneController
//{
//    private static int gamelvl; //At the end of the level you need to pass this the level number using getactive().buildindex
//    private static int replay = 1; //At the start of the level if gamelvl != buildindex, reset replay

//    public static void LoadScene(int lvl)
//    {
//        SceneManager.LoadScene(lvl);

//           DontDestroyOnLoad(this.gameObject);
//    }

//    public static void ReplayLvl()
//    {
//        if (replay > 0)
//        {
//            replay--;
//            SceneManager.LoadScene(gamelvl);
//            DontDestroyOnLoad(this.gameObject);
//        }
//        else if (replay == 0)
//        {
//            SceneManager.LoadScene(0);
//        }
//    }

//    public static void QuitGame()
//    {
//        Application.Quit();
//    }
//}
