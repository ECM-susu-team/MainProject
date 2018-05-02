using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
    GameObject APIClass;
    MainAPI api;

    public Dropdown dropdown;
    private List<string> itemList;
    private int count = 0;
	// Use this for initialization
	void Start () {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
        itemList =  api.getUserItems(GlobalControl.Instance.email);
        dropdown.ClearOptions();
        dropdown.AddOptions(itemList);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        count++;
        if(count == 100)
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(itemList);
        }
    }

}
