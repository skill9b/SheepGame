using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum Level
    {
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

   public Level level;
    public int check;

    void Start()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Level4.SetActive(false);
        Level5.SetActive(false);
        Level6.SetActive(false);

        level = Level.One;
        check = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((level == Level.One) && (check == 0))
        {
            //Level1.GetComponent<SpawningController>().state != SpawningController.SpawnState.END
            Level1.SetActive(true);


            check = 1;
        }
    }


}
