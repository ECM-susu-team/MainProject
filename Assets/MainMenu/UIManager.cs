using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject Play;
    public GameObject Login;
    public GameObject Reg;
   // public Text usefulInfo;
    public Text username;
   // public Text score;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalControl.Instance.isAuth == true)
        {
            Login.SetActive(false);
            Reg.SetActive(false);
            Play.SetActive(true);
            username.text = GlobalControl.Instance.email;
        }
        else
        {
            Play.SetActive(false);
        }
	}
}
