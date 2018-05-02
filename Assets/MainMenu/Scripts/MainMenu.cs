using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private int MainMenuIndex = 0;
    private int RegistrationIndex = 1;
    private int playSceneIndex = 2;
    private int LoginIndex = 3;
    private int CustomIndex = 4;

    public Text massage;

    public void Play ()
    {
            SceneManager.LoadScene(playSceneIndex);
    
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
