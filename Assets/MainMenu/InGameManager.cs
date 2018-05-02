using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Web;
using System.Runtime.Serialization;


public class InGameManager : MonoBehaviour {

    class UserData
    {

        private string email;
        private int score;

        public void setScore(int score)
        {
            this.score = score;
        }
        public int getScore()
        {
            return this.score;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return this.email;
        }
    }

    public void SaveData()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();

        form.AddField("email", GlobalControl.Instance.email);
        form.AddField("score", GlobalControl.Instance.score);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/api/users/setscore", form);
        yield return www.SendWebRequest();


        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        if (www.downloadHandler.text != "Bad Registration")
        {
            Debug.Log("HERE1:");
            Debug.Log(GlobalControl.Instance.score);
            Debug.Log(www.downloadHandler.text);
        }
    }
}
