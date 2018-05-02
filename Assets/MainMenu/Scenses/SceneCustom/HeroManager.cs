using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour {

    GameObject APIClass;
    MainAPI api;

    public Dropdown dropdown;
    private List<int> heroesIdList;
    private List<string> heroesList;
    private int count = 0;
    // Use this for initialization
    void Start()
    {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
        heroesIdList = api.getHeroesList(GlobalControl.Instance.email);
        Debug.Log("IN MANAGER");
        Debug.Log(heroesIdList[0]);
        Debug.Log(heroesIdList[1]);
        setHeroesList(heroesIdList);
        dropdown.ClearOptions();
        dropdown.AddOptions(heroesList);
    }
    
    void setHeroesList(List<int> heroesIdList)
    {
        heroesList = new List<string>();
        foreach (int heroId in heroesIdList)
        {
            if(heroId == 1)
            {
                heroesList.Add("Ninja");
            }

            if(heroId == 2)
            {
                heroesList.Add("Jedi");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dropdown.options[dropdown.value].text == "Ninja")
        {
            GlobalControl.Instance.heroName = "Ninja";
        }
        if (dropdown.options[dropdown.value].text == "Jedi")
        {
            GlobalControl.Instance.heroName = "Jedi";
        }
    }

    void FixedUpdate()
    {
        count++;
        if (count == 100)
        {
            setHeroesList(heroesIdList);
            dropdown.ClearOptions();
            dropdown.AddOptions(heroesList);
            count = 0;
        }
    }

}
