using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEnemies : MonoBehaviour {
    private int amount = 0, numberWaves = 0, amountWaves = 0, bufferWaves = 0;
    public GameObject[] enemies;
    public Text amountOfEnemies, numberOfWaves, amountOfWaves;
    GameObject WaveSpawnerClass;
    WaveSpawner ws;
    public API api;
    void Start () {
        WaveSpawnerClass = GameObject.Find("wavespawner");
        ws = WaveSpawnerClass.GetComponent<WaveSpawner>();
        amountWaves = ws.GetAmountOfWaves;
        amountOfWaves.text = amountWaves.ToString();

    }
	

	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (amount != enemies.Length)
        {
            amount = enemies.Length;
            amountOfEnemies.text = amount.ToString();
        }
        if (numberWaves!= ws.nextWave)
        {
            numberWaves = ws.nextWave;
            bufferWaves = numberWaves;
            bufferWaves++;
            numberOfWaves.text = bufferWaves.ToString();
        }
        
    }

}
