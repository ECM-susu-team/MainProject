using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour{
    GameObject WarriorClass;
    Warrior wrr;
    GameObject APIClass;
    MainAPI api;
    int[] idItems = new int[10];
    void Start()
    {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();

        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && (this.gameObject.tag == "First-aidKit"))
        {
            wrr.curHealth += 40;
            this.gameObject.SetActive(false);
        }
        if ((other.gameObject.tag == "Player") && (this.gameObject.name == "hat(Clone)"))
        {
            privateItems(1);
            this.gameObject.SetActive(false);
            api.setUserItem(GlobalControl.Instance.email, "Hat");
        }
    }
    public void privateItems(int _id)
    {
        idItems[0] = _id;
        Debug.Log("Haaaat");
    }
}
   