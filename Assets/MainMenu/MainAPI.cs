using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using UnityEngine.SceneManagement;
using System;
using System.Threading;


public class MainAPI : MonoBehaviour {

    private bool inFirst = false;
    private bool isEnd = false;
    private string locationName;
    private Location location;
    private Items items = new Items();
    private UserHeroes userHeroesObject = new UserHeroes();

    private List<string> itemList = new List<string>();
    private List<int> heroesList = new List<int>();

    private string levelGrade;
    private string treeGrade;

    [System.Serializable]
    public class Location
    {
        public int id;
        public string name;
        public int waves;
    }

    [System.Serializable]
    public class UserItems
    {
        public string email;
        public string itemName;

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setItemName(string itemName)
        {
            this.itemName = itemName;
        }
    }
    [System.Serializable]
    public class Item
    {
        public int id;
        public string itemName;
    }

    [System.Serializable]
    public class Items
    {
        public List<Item> userItemList = new List<Item>();
    }

    [System.Serializable]
    public class HeroCustom
    {
        public int id;
        public int userId;
        public int heroId;
        public string levelPath;
        public string treePath;
    }
    [System.Serializable]
    public class UserHeroes
    {
        public List<HeroCustom> userHeroes = new List<HeroCustom>();
    }

    [System.Serializable]
    public class UserEmail
    {
        public string email;

        public void setEmail(string email)
        {
            this.email = email;
        }
    }

    [System.Serializable]
    public class UserAndHero
    {
        public string hero_name;
        public string user_email;
    }

    [System.Serializable]
    public class UserHeroGrade
    {
        public string hero_name;
        public string user_email;
        public string grade;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //COUNT = location.waves;
	}

    public int getLocationWaves(int locationIndex)
    {
        StartCoroutine(UploadLocationInfo(locationIndex));
        return location.waves;
    }

    public void setUserItem(string email,string itemName)
    {
        StartCoroutine(UploadCatchingItem(email,itemName));
    }


    public List<string> getUserItems(string email)
    {
        StartCoroutine(UploadUserItem(email));
        Invoke("Run", 2f);
        Debug.Log("asdaz");
        //while (!isEnd) { }
        return itemList;
    }
    void Run()
    {
        Debug.Log("RUN");
        isEnd = true;
    }

    public List<int> getHeroesList(string email)
    {
        StartCoroutine(UploadUserHeroes(email));
        return heroesList;
    }

    public string getLevelGrade(string email,string heroName)
    {
        StartCoroutine(UploadLevelGrade(email, heroName));
        return levelGrade;
    }

    public void getTreeGrade(string email,string heroName)
    {
        StartCoroutine(UploadTreeGrade(email, heroName));
    }
    public void setLevelGrade(string email,string heroName,string grade)
    {
        StartCoroutine(UploadSetLevelGrade(email, heroName, grade));
    }


    public void Login(string email,string password)
    {
        StartCoroutine(UploadLogin(email, password));
    }
    IEnumerator UploadLocationInfo(int locationIndex)
    {
        switch (locationIndex)
        {
            case 0:
                locationName = "Japan";
                break;
            case 1:
                locationName = "Russia";
                break;
            default:

                break;
        }
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/api/locations/"+locationName);
        yield return www.SendWebRequest();


        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        if (www.downloadHandler.text != "Bad Registration")
        {

            location = (Location)JsonUtility.FromJson<Location>(www.downloadHandler.text);
            Debug.Log("UUUUUU");
            Debug.Log(location.name);
            Debug.Log("UUUUU");
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator UploadCatchingItem(string email, string itemName)
    {
       /* WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/api/locations/",form);
        yield return www.SendWebRequest();*/

        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserItems userItems = new UserItems();
        userItems.setEmail(email);
        userItems.setItemName(itemName);
        // convert json string to byte
        string json = JsonUtility.ToJson(userItems);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);

        www = new WWW("http://localhost:8080/api/setItem", formData, postHeader);

        yield return www;

    }

    IEnumerator UploadUserItem(string email)
    {
        inFirst = true;
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserEmail ue = new UserEmail();
        ue.setEmail(email);
        // convert json string to byte
        string json = JsonUtility.ToJson(ue);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        Debug.Log("1");
        www = new WWW("http://localhost:8080/api/getItems", formData, postHeader);

        yield return www;
        Debug.Log("ITEM LIST");
        Debug.Log(www.text);
        items = JsonUtility.FromJson<Items>(www.text);
        foreach (Item item in items.userItemList)
        {
            Debug.Log(item.itemName);
            itemList.Add(item.itemName);
        }
        Debug.Log("END");
        inFirst = false;
    }

    IEnumerator UploadUserHeroes(string email)
    {
        //inFirst = true;
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserEmail ue = new UserEmail();
        ue.setEmail(email);
        // convert json string to byte
        string json = JsonUtility.ToJson(ue);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        Debug.Log("8719236");
        www = new WWW("http://localhost:8080/api/getHeroesByUser", formData, postHeader);

        yield return www;
        userHeroesObject = JsonUtility.FromJson<UserHeroes>(www.text);
        Debug.Log("HERE LIST");
        Debug.Log(www.text);
        foreach (HeroCustom heroCustom in userHeroesObject.userHeroes)
        {
            Debug.Log("ID HEROES");
            Debug.Log(heroCustom.levelPath);
            heroesList.Add(heroCustom.heroId);
        }
        Debug.Log(heroesList[0]);
        Debug.Log(heroesList[1]);
        Debug.Log("END LIST");
        //inFirst = false;
    }

    IEnumerator UploadLevelGrade(string email,string heroName)
    {
        //inFirst = true;
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserAndHero userAndHero = new UserAndHero();
        userAndHero.user_email = email;
        userAndHero.hero_name = heroName;
        // convert json string to byte
        string json = JsonUtility.ToJson(userAndHero);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        Debug.Log("IN GRADE");
        Debug.Log(userAndHero);
        Debug.Log(json);
        www = new WWW("http://localhost:8080/api/getHeroCustom", formData, postHeader);

        yield return www;

        Debug.Log(www.text);
        HeroCustom heroCustom = new HeroCustom();
        heroCustom = JsonUtility.FromJson<HeroCustom>(www.text);

        Debug.Log("GRADE!!!!");
        Debug.Log(heroCustom.levelPath);
        GlobalControl.Instance.LevelGrade = heroCustom.levelPath;
        Debug.Log(levelGrade);
        //inFirst = false;
    }


    IEnumerator UploadTreeGrade(string email, string heroName)
    {
        //inFirst = true;
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserAndHero userAndHero = new UserAndHero();
        userAndHero.user_email = email;
        userAndHero.hero_name = heroName;
        // convert json string to byte
        string json = JsonUtility.ToJson(userAndHero);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        Debug.Log("IN GRADE");
        Debug.Log(userAndHero);
        Debug.Log(json);
        www = new WWW("http://localhost:8080/api/getHeroCustom", formData, postHeader);

        yield return www;

        Debug.Log(www.text);
        HeroCustom heroCustom = new HeroCustom();
        heroCustom = JsonUtility.FromJson<HeroCustom>(www.text);

        Debug.Log("GRADE!!!!");
        Debug.Log(heroCustom.levelPath);
        GlobalControl.Instance.TreeGrade = heroCustom.treePath;
        Debug.Log(levelGrade);
        //inFirst = false;
    }

    //set`s for Grades
    IEnumerator UploadSetLevelGrade(string email, string heroName,string grade)
    {
        //inFirst = true;
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserHeroGrade userHeroGrade = new UserHeroGrade();
        userHeroGrade.hero_name = heroName;
        userHeroGrade.user_email = email;
        userHeroGrade.grade = grade;
        // convert json string to byte
        string json = JsonUtility.ToJson(userHeroGrade);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        //Debug.Log("IN GRADE");
        //Debug.Log(userAndHero);
        //Debug.Log(json);
        www = new WWW("http://localhost:8080/api/setLevelGrade", formData, postHeader);

        yield return www;
    
        //inFirst = false;
    }


    IEnumerator UploadLogin(string email,string password)
    {
        WWWForm form = new WWWForm();

        form.AddField("email", email);
        form.AddField("password", password);

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
    public void Waiter()
    {
        int b;
      
    }

}
