using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{


    public void SaveData()
    {
        //StartCoroutine(Upload());
        //StartCoroutine(UploadLevelGrade(GlobalControl.Instance.email, GlobalControl.Instance.heroName, GlobalControl.Instance.LevelGrade));
        SceneManager.LoadScene(0);
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
    [System.Serializable]
    public class LevelGrade
    {
        public string hero_name;
        public string user_email;
        public string grade;
    }
    IEnumerator UploadLevelGrade(string email, string heroName,string levelGrade)
    {
        //inFirst = true;
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        LevelGrade level = new LevelGrade();
        level.user_email = email;
        level.hero_name = heroName;
        level.grade = levelGrade;
        // convert json string to byte
        string json = JsonUtility.ToJson(level);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        Debug.Log(json);
        www = new WWW("http://localhost:8080/api/setLevelGrade", formData, postHeader);

        yield return www;

        //inFirst = false;
    }
}
