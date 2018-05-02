using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    public string email;
    public bool isAuth = false;
    public int score;
    private int LocationIndex = 0;

    public string heroName;
    public string LevelGrade;
    public string TreeGrade;
    void Awake()
    {

        if (Instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int getLocationIndex()
    {
        return LocationIndex;
    }
    public void setLocationIndex(int LocationIndex)
    {
        this.LocationIndex = LocationIndex;
    }
}
