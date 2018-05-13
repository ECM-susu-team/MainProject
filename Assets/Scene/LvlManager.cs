using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour {
    GameObject WarriorClass;
    Warrior wrr;
    public bool nextLvlTree;

    public int countLVL = 1, _lvlForUnblockSkills = 0, _lvlForSkills = 0;
    private float nextLvl = 100f;
    void Start () {
        nextLvlTree = false;
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();
    }
	
	void Update () {
        if (wrr.pXP >= nextLvl)
        {
            nextLvlTree = true;
            countLVL++;
            wrr.level = countLVL;
            wrr.pXP = 1f;
            nextLvl +=20;
            _lvlForUnblockSkills++;
            _lvlForSkills++;
        }
	}
    public double GetNextLvl
    {
        get { return nextLvl; }
    }
    public int lvlForUnblockSkills
    {
        get { return _lvlForUnblockSkills; }
        set { _lvlForUnblockSkills = value; }
    }
    public int lvlForSkills
    {
        get { return _lvlForSkills; }
        set { _lvlForSkills = value; }
    }
}
