using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Poot made this
*/
public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        //public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

//winstate stuff
    public DistanceProgression DP;
    public int totalWaves;
    public int waveProgression;
    public GameObject YouWinUI;
// end winstate stuff

    public Transform[] enemies;

    public Transform[] spawnPoints;
    public float timeBetweenWaves = 20f;
    public float waveCountdown;

    private float searchCountdown = 10f;
    private SpawnState state = SpawnState.COUNTING;
    public GameObject spawnEffect;

    void Start()
    { 
        if (spawnPoints.Length == 0)
        {
            Debug.LogError ("No spawn points referenced");
        }

        totalWaves = waves.Length;
        waveProgression = totalWaves;
        DP.SetMaxDistance(totalWaves);


        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //begin new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //start spawning waves
                StartCoroutine( SpawnWave ( waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    
    void WaveCompleted()
    {
        Debug.Log("Wave Completed bro");
        waveProgression = waveProgression - 1;
        DP.SetDistance(waveProgression);
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("All Waves completed");
            WinState();
        }
        else
        {
            nextWave++;
        }

        
    }
    public bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 10f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);

        state = SpawnState.SPAWNING;
        //spawn stuff

        for (int i =0; i < _wave.count; i++)
        {
            Transform _enemyTypes = enemies[Random.Range(0, enemies.Length)];
            //SpawnEnemy(_wave.enemy);
            SpawnEnemy(_enemyTypes);
            
                
            yield return new WaitForSeconds( 1f / _wave.rate);
        }

        

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemyTypes)
    {
        //Spawn enemy
        Debug.Log ("Spawning Enemy: " + _enemyTypes.name);
        //Transform _enemyTypes = enemies[Random.Range(0, enemies.Length)];

        
        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length)];
        Instantiate(spawnEffect, _sp.position, Quaternion.identity);
        Instantiate(_enemyTypes, _sp.position, transform.rotation);
        
    }


    void WinState()
    {

        Time.timeScale = 0f;
        YouWinUI.SetActive(true);
    }

}
