using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour {
    GameObject WaveSpawnerClass;
    public GameObject Item;
    WaveSpawner ws;
    public int randomWave, randomCoord;
    private bool flag = true;
    void Start () {
        WaveSpawnerClass = GameObject.Find("wavespawner");
        ws = WaveSpawnerClass.GetComponent<WaveSpawner>();
        //randomWave = Random.Range(0, ws.GetAmountOfWaves);
        //randomCoord = Random.Range(1,3);
        randomWave = 0;
        randomCoord = 3;
    }
	
	void Update () {
        if ( (randomWave == ws.nextWave) && (flag == true))
        {
            if (randomCoord == 1)
                Instantiate(Item, new Vector3(97.86f, 16.15f, 0), Quaternion.identity);
            if (randomCoord == 2)
                Instantiate(Item, new Vector3(193.56f, 2.29f, 0), Quaternion.identity);
            if (randomCoord == 3)
                Instantiate(Item, new Vector3(39.96f, 18.44f, 0), Quaternion.identity);
            flag = false;
        }
    }
}
