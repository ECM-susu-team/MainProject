using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public MainAPI api;
    public enum SpawnState { spawning, waiting, counting }
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
        // public float complexity;
        //TODO: the wave randomly spawn enemies untill reach complexity lvl;

    }
    public Wave[] waves;
    private int _nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float _searchDelay=1f;
    private SpawnState _state = SpawnState.counting;
    void Start()
    {
        if (SpawnPoints.Length == 0)
        {
            Debug.Log("No spawn points");
        }
        waves = new Wave[api.getLocationWaves(GlobalControl.Instance.getLocationIndex())];
        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if(_state==SpawnState.waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveDone();
                // Invoke new round
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (_state != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[_nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    bool EnemyIsAlive()
    {
        _searchDelay -= Time.deltaTime;
        if (_searchDelay <=0)
        {
            _searchDelay = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true; // TODO: back to TRUE!
    }

    public Transform[] SpawnPoints;

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        _state = SpawnState.spawning;
        //spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        _state = SpawnState.waiting;
        yield break;
    }
    void WaveDone()
    {
        Debug.Log("Wave Completed");
        _state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;
        if (_nextWave + 1 > waves.Length -1)
        {
            _nextWave = 0;
            Debug.Log("No more Waves. Starts 1st Wave");
        }
        else 
        _nextWave++;
    }
    void SpawnEnemy(Transform _enemy)
    {
 //spawn
       Debug.Log("Spawning Enemy: " + _enemy.name);

        if (SpawnPoints.Length ==0)
        {
            Debug.Log("No spawn points");
        }
        Transform sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
    }
    public int nextWave
    {
        get { return _nextWave; }
        set { _nextWave = value; }
    }
    public int GetAmountOfWaves
    {
        get { return waves.Length; }
    }
}   
