using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuController : MonoBehaviour {
    public GameObject go;
    bool wasActive;
	// Use this for initialization
	void Start () {
        go.SetActive(false);
        wasActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setMenu()
    {
        if (wasActive == true)
        {
            go.SetActive(false);
            Time.timeScale = 1;
            wasActive = false;
        }
        else
        {
            go.SetActive(true);
            Time.timeScale = 0;
            wasActive = true;
        }
    }
}
