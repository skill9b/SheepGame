using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{

    // ******** VARIABLES ******** //
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    }

    private SpawnState state = SpawnState.COUNTING;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform sheepEnemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int waveCount = 0;   // default is 0

    // public Transform[] spawnPoints;
    public Transform SpawnPointTop;
    public Transform SpawnPointBottom;

    public float timeBetweenWaves = 5.0f;   // 5 seconds
    private float waveCountdown;

    private float searchCountdown = 1.0f;


    // ******** FUNCTIONS ******** //
    void Start()
    {
        //if (spawnPoints.Length == 0)
        //{
        //    Debug.LogError("No spawn points referenced.");
        //}
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        // Check if player has killed all the enemies
        if (state == SpawnState.WAITING)
        {
            // Check if any enemies are still alive
            if (!isEnemyAlive())
            {
                // Begin new round
                startNextWave();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            // Spawn wave condition
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[waveCount]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;    // countsdown second by second
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        // Spawn logic
        for (int i = 0; i < _wave.count; i++)
        {

            //Transform enemyToSpawn;
            //float rate = Random.Range(0.0f, 1.0f);

            //if (rate < 0.6)
            //{
            //    enemyToSpawn = _wave.firstEnemy;
            //}
            //else if (rate < 0.8)
            //{
            //    enemyToSpawn = _wave.secondEnemy;

            //}
            //else
            //{
            //    enemyToSpawn = _wave.thirdEnemy;
            //}

            SpawnEnemy(_wave.sheepEnemy);
            yield return new WaitForSeconds(1.0f / _wave.rate); // wait before spawning next enemy
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        // Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // x point of SpawnPointTop, random y point between SpawnPointTop & SpawnPointBottom

        float randomY = Random.Range((int)SpawnPointTop.position.y, (int)SpawnPointBottom.position.y);
        Vector3 position = new Vector3(SpawnPointTop.position.x, randomY, SpawnPointTop.position.z);
        Instantiate(_enemy, position, SpawnPointTop.rotation);
        Debug.Log("Spawning enemy: " + _enemy.name);
    }

    void startNextWave()
    {
        Debug.Log("Wave completed.");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (waveCount + 1 > waves.Length - 1)
        {
            waveCount = 0;
            Debug.Log("All waves complete!");
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
