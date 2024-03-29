﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningController : MonoBehaviour
{
    // ******** VARIABLES ******** //
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING,
        END
    }

    public SpawnState state = SpawnState.COUNTING;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform sheep;
        public int count;
        public float rate = 1;
        public float timeToNextWave;
    }

    public Wave[] waves;
    private int waveCount = 0;   // default is 0
    
    public Transform SpawnPointTop;
    public Transform SpawnPointBottom;

    float timeBetweenWaves;
    private float waveCountdown;
    private float searchCountdown = 1.0f;

    public int deadSheep;
    int currentWaveMaxSheep;

    // UI elements
    Text remainingWaves;
    GameObject upgradesMenu;

    // ******** FUNCTIONS ******** //
    void Start()
    {
        currentWaveMaxSheep = waves[0].count;

        remainingWaves = GameObject.FindGameObjectWithTag("RemainingWaves").GetComponent<Text>();
        upgradesMenu = GameObject.FindGameObjectWithTag("UpgradesMenu");
    }

    void Update()
    {
        // Check if player has killed all the enemies
        if (state == SpawnState.WAITING)
        {
            timeBetweenWaves -= Time.deltaTime;
            
            if (timeBetweenWaves <= 0)
            {
                Debug.Log("Starting next wave!");
                startNextWave();
            }
            return;
        }

        if (waveCountdown <= 0)
        {
            if ((state == SpawnState.END) && (GameObject.FindGameObjectsWithTag("Enemy").Length == 0))
            // if ((waveCount == -1) && (GameObject.FindGameObjectsWithTag("Enemy").Length == 0))
            {
                //  Debug.Log("Enemies left:" + (GameObject.FindGameObjectsWithTag("Enemy").Length));
                //  // waveCount = 0;
                //  
                //  upgradesMenu.SetActive(true);
                //  // set everything else to inactive???
                //  GameObject.FindGameObjectWithTag("Base").SetActive(false);
                //  Debug.Log("All waves complete!");

                //
                if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().currentlevel != GameController.Level.Six)
                {
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>().currentlevel = GameController.Level.Inbetween;
                }
                else
                {
                    //Win Game
                    ////GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().WinScreen();
                }



            }

            // Spawn wave condition
            if ((state != SpawnState.SPAWNING) && (state != SpawnState.END))
            {   
                StartCoroutine(SpawnWave(waves[waveCount]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;    // counts down second by second
        }

        // Display remaining waves and sheep in current wave
        remainingWaves.text = "Remaining Waves: " + (waves.Length - waveCount).ToString();

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        // Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        currentWaveMaxSheep = _wave.count;

        timeBetweenWaves = _wave.timeToNextWave;
        Debug.Log("SpawningWave: " + _wave.name + " & time = " + timeBetweenWaves);

        // Spawn logic
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.sheep);

            yield return new WaitForSeconds(1.0f / _wave.rate); // Wait before spawning next enemy
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        float randomY = Random.Range(SpawnPointTop.position.y, SpawnPointBottom.position.y);
        Vector3 position = new Vector3(SpawnPointTop.position.x, randomY, SpawnPointTop.position.z);
        Instantiate(_enemy, position, SpawnPointTop.rotation);
        // Debug.Log("Spawning enemy: " + _enemy.name);
    }

    void startNextWave()
    {
        Debug.Log("Wave completed.");

        deadSheep = 0;

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (waveCount + 1 > waves.Length - 1)
        {
            waveCount = 0;
            state = SpawnState.END;
        }
        else
        {
            waveCount++;
        }
    }

    bool isEnemyAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0.0f)
        {
            searchCountdown = 1.0f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }

        return true;
    }

}
