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

    GameObject APIClass;
    MainAPI api;

    private int MainMenuIndex = 0;

    bool start = false;
    int i = 0;
    /*void Awake()
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
    }*/
    private void Start()
    {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
    }
    public class User
    {
        public string email;
        public string username;
        public string password;

    }

    void FixedUpdate()
    {
      if(start == true)
        {
            i++;
            if (i == 100)
            {
                start = false;
                GetBack();
            }
        }
    }
    public void Clicked()
    {
        //StartCoroutine(Upload());
        api.Login(email.text, password.text);
        start = true;
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
