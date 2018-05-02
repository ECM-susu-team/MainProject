using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationManager1 : MonoBehaviour {

    public Text Label;
    public int LocationIndex;
    public Dropdown dropdown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (dropdown.value)
        {
            case 0:
                LocationIndex = 0;
                break;
            case 1:
                LocationIndex = 1;
                break;
            default:
                
                break;
        }
    }

    public int getLocationIndex()
    {
        return LocationIndex;
    }
}
