using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDates : MonoBehaviour {

    GameObject APIClass;
    MainAPI api;
    // Use this for initialization
    void Start () {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveData()
    {
        api.setLevelGrade(GlobalControl.Instance.email, GlobalControl.Instance.heroName, GlobalControl.Instance.LevelGrade);
    }
}
