using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class APILogin : MonoBehaviour
{

    public InputField email;
    public InputField password;



    public class User
    {
        public string email;
        public string username;
        public string password;

    }

    public void Clicked()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();

        form.AddField("email", email.text);
        form.AddField("password", password.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/api/login", form);
        yield return www.SendWebRequest();
        

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form LOGIN upload complete!");
            Debug.Log(www.downloadHandler.text);
            Debug.Log(www.url);
        }
    }
}
