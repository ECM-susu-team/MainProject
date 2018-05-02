using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public static Login login;

    public InputField email;
    public InputField password;

    private int MainMenuIndex = 0;
    void Awake()
    {

        if (login == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            login = this;
        }
        else if (login != this)
        {
            Destroy(gameObject);
        }
    }
    public class User
    {
        public string email;
        public string username;
        public string password;

    }

    public void Clicked()
    {
        StartCoroutine(Upload());
        GetBack();
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
        if (www.downloadHandler.text != "Bad Registration")
        {

            GlobalControl.Instance.email = www.downloadHandler.text;
            GlobalControl.Instance.isAuth = true;

            Debug.Log(GlobalControl.Instance.email);
        }
    }
    public void GetBack()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }

    public void SaveData()
    {
        Debug.Log("IN ");
        StartCoroutine(UploadData());
        GetBack();
    }

    IEnumerator UploadData()
    {
        WWWForm form = new WWWForm();

        form.AddField("email", GlobalControl.Instance.email);
        form.AddField("score", GlobalControl.Instance.score);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/api/users/setscore", form);
        yield return www.SendWebRequest();

        Debug.Log("IN ");
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
