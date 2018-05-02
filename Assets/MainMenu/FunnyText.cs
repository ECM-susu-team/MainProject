using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyText : MonoBehaviour {
    public MainAPI mainApi;
    public int locationWaves = 0;
	// Use this for initialization
	void Start () {
        locationWaves = mainApi.getLocationWaves(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
