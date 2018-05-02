using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Confirm : MonoBehaviour {

    GameObject APIClass;
    MainAPI api;
    public Image first;
    public Image second;
    public Image third;
    // Use this for initialization
    int count = 0;
    void Start () {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
        first.enabled = false;
        second.enabled = false;
        third.enabled = false;
    }

    void FixedUpdate()
    {
       
            setRect();
            //count = 0;
        
    }

    public void ConfirmData()
    {
        GlobalControl.Instance.LevelGrade = api.getLevelGrade(GlobalControl.Instance.email, GlobalControl.Instance.heroName);
      
    }

    void setRect()
    {
        string str = GlobalControl.Instance.LevelGrade;
        char[] charArray = str.ToCharArray(0, 5);
        int firstChar = (int)Char.GetNumericValue(charArray[0]);
        int secondChar = (int)Char.GetNumericValue(charArray[2]);
        int thirdChar = (int)Char.GetNumericValue(charArray[4]);

        Debug.Log("CONF");
        Debug.Log(GlobalControl.Instance.LevelGrade);
        Debug.Log(firstChar);
        Debug.Log(secondChar);
        Debug.Log(thirdChar);
        first.rectTransform.sizeDelta = new Vector2(50, 30 * firstChar);
        second.rectTransform.sizeDelta = new Vector2(50, 30 * secondChar);
        third.rectTransform.sizeDelta = new Vector2(50, 30 * thirdChar);

        first.rectTransform.anchoredPosition = new Vector2(80, 40+15* firstChar);
        second.rectTransform.anchoredPosition = new Vector2(150, 40+15* secondChar);
        third.rectTransform.anchoredPosition = new Vector2(240, 40+15* thirdChar);

        first.enabled = true;
        second.enabled = true;
        third.enabled = true;

        //GlobalControl.Instance.LevelGrade = "3-2-1";
    }
	// Update is called once per frame

}
