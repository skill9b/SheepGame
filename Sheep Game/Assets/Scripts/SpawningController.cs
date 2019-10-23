using System.Collections;
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
        COUNTING
    }

    private SpawnState state = SpawnState.COUNTING;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform sheepMelee;
        public Transform sheepFat;
        public Transform sheepRam;
        public Transform sheepFast;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int waveCount = 0;   // default is 0
    
    public Transform SpawnPointTop;
    public Transform SpawnPointBottom;

    public float timeBetweenWaves = 5.0f;   // 5 seconds
    private float waveCountdown;
    private float searchCountdown = 1.0f;

    public Text remainingWaves;
    public Text remainingSheep;
    public int deadSheep;
    int currentWaveMaxSheep;

    // ******** FUNCTIONS ******** //
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWaveMaxSheep = waves[0].count;
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

        // Display remaining waves and sheep in current wave
        remainingWaves.text = "Remaining Waves: " + (waves.Length - waveCount).ToString();
        remainingSheep.text = "Remaining Sheep: " + (currentWaveMaxSheep - deadSheep).ToString();
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        // Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        currentWaveMaxSheep = _wave.count;

        // Spawn logic
        for (int i = 0; i < _wave.count; i++)
        {

            Transform enemyToSpawn;
            float rate = Random.Range(0.0f, 1.0f);

            if (rate < 0.25)
            {
                enemyToSpawn = _wave.sheepMelee;
            }
            else if (rate < 0.5)
            {
                enemyToSpawn = _wave.sheepFat;

            }
            else if (rate < 0.75)
            {
                enemyToSpawn = _wave.sheepRam;

            }
            else
            {
                enemyToSpawn = _wave.sheepFast;
            }

            SpawnEnemy(enemyToSpawn);

            //SpawnEnemy(_wave.sheepMelee);
            //SpawnEnemy(_wave.sheepFat);
            //SpawnEnemy(_wave.sheepRam);
            //SpawnEnemy(_wave.sheepFast);

            yield return new WaitForSeconds(1.0f / _wave.rate); // wait before spawning next enemy
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        float randomY = Random.Range((int)SpawnPointTop.position.y, (int)SpawnPointBottom.position.y);
        Vector3 position = new Vector3(SpawnPointTop.position.x, randomY, SpawnPointTop.position.z);
        Instantiate(_enemy, position, SpawnPointTop.rotation);
        // Debug.Log("Spawning enemy: " + _enemy.name);
    }

    void startNextWave()
    {
        // Debug.Log("Wave completed.");

        deadSheep = 0;

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (waveCount + 1 > waves.Length - 1)
        {
            waveCount = 0;
            // Debug.Log("All waves complete!");
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
