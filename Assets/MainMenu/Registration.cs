using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{

    public InputField email;
    public InputField username;
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
        GetBack();
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();

        form.AddField("email", email.text);
        form.AddField("username", username.text);
        form.AddField("password", password.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/api/registration", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
        }
    }

    public void GetBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
