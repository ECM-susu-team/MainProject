using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosingLocation : MonoBehaviour
{
    GameObject APIClass;
    MainAPI api;
    private int MainMenuIndex = 0;
    private int RegistrationIndex = 1;
    private int playSceneIndex = 2;
    private int LoginIndex = 3;
    private int CustomIndex = 4;

    private int RussiaIndex = 5;

    public int b;
    public Text massage;
    public LocationManager1 locationManager;

    public Dropdown levelDropDown;
    public Dropdown itemDropDown;
    public Dropdown heroDropDown;
    //private LocationManager script;
    void Start()
    {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
    }
    public void Play()
    {
        //GlobalControl.Instance.LevelGrade = api.getLevelGrade(GlobalControl.Instance.email, GlobalControl.Instance.heroName);
        switch (locationManager.getLocationIndex())
        {
            case 0:
                GlobalControl.Instance.setLocationIndex(locationManager.getLocationIndex());
                SceneManager.LoadScene(playSceneIndex);
                break;
            case 1:
                GlobalControl.Instance.setLocationIndex(locationManager.getLocationIndex());
                SceneManager.LoadScene(RussiaIndex);
                break;
          
        }

    }

    public void SignIn()
    {
        SceneManager.LoadScene(LoginIndex);
    }
    public void SignOn()
    {
        SceneManager.LoadScene(RegistrationIndex);
    }
    public void Custom()
    {
        SceneManager.LoadScene(CustomIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
