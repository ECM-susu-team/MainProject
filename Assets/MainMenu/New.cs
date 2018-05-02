using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class New : MonoBehaviour
{


    void SaveData()
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
        }
    }
}
