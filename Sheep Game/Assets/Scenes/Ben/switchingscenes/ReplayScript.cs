//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class ReplayScript : MonoBehaviour
//{
//    public SceneController TheController;

//    private void Start()
//    {
//        if (TheController.gamelvl != SceneManager.GetActiveScene().buildIndex)
//        {
//            Debug.Log(SceneManager.GetActiveScene().buildIndex);
//            TheController.replay = 1;
//        }
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            TheController.gamelvl = SceneManager.GetActiveScene().buildIndex;
//            SceneManager.LoadScene(3);
//        }
//    }

//}
