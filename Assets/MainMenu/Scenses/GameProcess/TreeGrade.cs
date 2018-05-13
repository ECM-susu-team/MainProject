using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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
    public Text lvltext;
    GameObject WarriorClass;
    Warrior wrr;
    LvlManager manager;
    public int treelevel = 0;
    string level;
    bool next;
    // Use this for initialization
    void Start()
    {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();
        manager = WarriorClass.GetComponent<LvlManager>();

        go.SetActive(false);
        wasActive = false;
        next = false;
        level = lvltext.text;
        if (GlobalControl.Instance.TreeGrade == "0")
        {
            RootNode.SetActive(false);
            Node2.SetActive(false);
            Node3.SetActive(false);
            Node3.SetActive(false);
            Node4.SetActive(false);

            stick1.SetActive(false);
            stick2.SetActive(false);
            stick3.SetActive(false);
        }else
        {
            char[] charArray = GlobalControl.Instance.TreeGrade.ToCharArray(0, 5);
            int firstChar = (int)Char.GetNumericValue(charArray[0]);
            treelevel = firstChar;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(level != lvltext.text) {
            level = lvltext.text;
            next = true;
        }
        if((next == true)&&(treelevel==0))
        {
            RootNode.SetActive(true);
            treelevel++;
            next = false;
        }
        if ((next == true) && (treelevel == 1))
        {
            Node2.SetActive(true);
            Node3.SetActive(true);
            stick1.SetActive(true);
            stick2.SetActive(true);
            treelevel++;
            next = false;
        }
        if ((next == true) && (treelevel == 2))
        {
            Node4.SetActive(true);
            stick3.SetActive(true);
            treelevel++;
            next = false;
        }
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
        //Node2.SetActive(true);
        //Node3.SetActive(true);

        //stick1.SetActive(true);
        //stick2.SetActive(true);

        GlobalControl.Instance.TreeGrade = "1-1";
    }
    
    public void InvokeNode2()
    {
        wrr.SetSpeed(wrr.GetSpeed() * 2);
        //Node3.SetActive(false);
        GlobalControl.Instance.TreeGrade = "2-1";
    }

    public void InvokeNode3()
    {
        wrr.maxHealth *= 2;
        Node2.SetActive(false);
        //Node4.SetActive(true);
        //stick3.SetActive(true);
        GlobalControl.Instance.TreeGrade = "2-2";
    }
}
