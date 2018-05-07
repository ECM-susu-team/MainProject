using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrade : MonoBehaviour {

    public GameObject go;
    bool wasActive;

    public GameObject RootNode;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;

    public GameObject stick1;
    public GameObject stick2;
    public GameObject stick3;
    GameObject WarriorClass;
    Warrior wrr;
    // Use this for initialization
    void Start()
    {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();

        go.SetActive(false);
        wasActive = false;
        Node2.SetActive(false);
        Node3.SetActive(false);
        Node3.SetActive(false);
        Node4.SetActive(false);

        stick1.SetActive(false);
        stick2.SetActive(false);
        stick3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTree()
    {
        if (wasActive == true)
        {
            go.SetActive(false);
            Time.timeScale = 1;
            wasActive = false;
        }
        else
        {
            go.SetActive(true);
            Time.timeScale = 0;
            wasActive = true;
        }
    }

    public void InvokeRootNode()
    {
        wrr.maxHealth += 20;
        Node2.SetActive(true);
        Node3.SetActive(true);

        stick1.SetActive(true);
        stick2.SetActive(true);
    }
    
    public void InvokeNode2()
    {
        wrr.SetSpeed(wrr.GetSpeed() * 2);
    }

    public void InvokeNode3()
    {
        wrr.maxHealth *= 2;
        Node4.SetActive(true);
        stick3.SetActive(true);
    }
}
