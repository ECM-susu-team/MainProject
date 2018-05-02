using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamerManager : MonoBehaviour
{

    public Text usernameText;
    public GameObject Login;
    bool isAuth = false;
    
    // Use this for initialization
    void Start()
    {
        usernameText.text = GlobalControl.Instance.email;
        //Login.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        usernameText.text = GlobalControl.Instance.email;
        //if (GlobalControl.Instance.isAuth==true)
        {
         //  usernameText.text = GlobalControl.Instance.email;
           //Login.SetActive(false);
        }
    }
}