using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillManagerScene : MonoBehaviour
{

    GameObject WarriorClass, LvlManagerClass;
    LvlManager lvlmng;
    Warrior wrr;
    GameObject APIClass;
    MainAPI api;
    public GameObject UnblockButton1, UnblockButton2, UnblockButton3;
    public Button Skill1, Skill2, Skill3;
    public GameObject LvlUpSkill1, LvlUpSkill2, LvlUpSkill3;
    public GameObject Img1Skill1Lvl, Img1Skill2Lvl, Img1Skill3Lvl, Img1Skill4Lvl, Img2Skill1Lvl, Img2Skill2Lvl, Img2Skill3Lvl, Img2Skill4Lvl, Img3Skill1Lvl, Img3Skill2Lvl, Img3Skill3Lvl, Img3Skill4Lvl;

    public bool[] unlockedAb;  //массив, который показывает, разблокирован (тру) или заблокирован (фолс)
    public int[] levelAb;      //уровень каждого из скилов
    public int _level;     //общий уровень игрока
    int lvlForSkills = 1;
    bool flagLvlFirSkills = false;

    public bool treeIsActive = false;

    void Start()
    {
        APIClass = GameObject.Find("API");
        api = APIClass.GetComponent<MainAPI>();

        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();

        LvlManagerClass = GameObject.Find("Main Camera");
        lvlmng = LvlManagerClass.GetComponent<LvlManager>();

        unlockedAb = new bool[3];                       //инициализация
        levelAb = new int[3];
        unlockedAb = wrr.unlockedabilities;
        levelAb = wrr.levelofabilities;
        _level = wrr.level;
        string str = GlobalControl.Instance.LevelGrade;
        char[] charArray = str.ToCharArray(0, 5);
        int firstChar = (int)Char.GetNumericValue(charArray[0]);
        int secondChar = (int)Char.GetNumericValue(charArray[2]);
        int thirdChar = (int)Char.GetNumericValue(charArray[4]);
        _level = wrr.level;
        unlockedAb[0] = true;
        unlockedAb[1] = true;
        unlockedAb[2] = true;
        levelAb[0] = firstChar;
        levelAb[1] = secondChar;
        levelAb[2] = thirdChar;

        UnblockButton1.SetActive(false);
        UnblockButton2.SetActive(false);
        UnblockButton3.SetActive(false);

        Skill1.interactable = false;
        Skill2.interactable = false;
        Skill3.interactable = false;

        LvlUpSkill1.SetActive(false);
        LvlUpSkill2.SetActive(false);
        LvlUpSkill3.SetActive(false);

        Img1Skill1Lvl.SetActive(false);
        Img1Skill2Lvl.SetActive(false);
        Img1Skill3Lvl.SetActive(false);
        Img1Skill4Lvl.SetActive(false);
        Img2Skill1Lvl.SetActive(false);
        Img2Skill2Lvl.SetActive(false);
        Img2Skill3Lvl.SetActive(false);
        Img2Skill4Lvl.SetActive(false);
        Img3Skill1Lvl.SetActive(false);
        Img3Skill2Lvl.SetActive(false);
        Img3Skill3Lvl.SetActive(false);
        Img3Skill4Lvl.SetActive(false);
    }

    public void Decrement(int IDSKILL)  //уменьшить уровень скила сюда посылать ID ВНИМАНИЕ 1,2,3 !!!
    {
        if (unlockedAb[IDSKILL - 1] == false)
            return;
        else
        {
            if (levelAb[IDSKILL - 1] > 0)
            {
                levelAb[IDSKILL - 1]--;
                _level++;
            }
        }
    }
    public void Increment(int IDSKILL)  //увеличить уровень скила сюда посылать ID ВНИМАНИЕ 1,2,3 !!!
    {
        if (unlockedAb[IDSKILL - 1] == false)
            return;
        else
        {
            if (lvlmng.lvlForSkills > 0)
            {
                levelAb[IDSKILL - 1]++;
                lvlmng.lvlForUnblockSkills--;
                lvlmng.lvlForSkills--;
            }
        }
    }
    public void UnlockAbility(int IDSKILL)  //разблокировать заблокированное... сюда посылать ID ВНИМАНИЕ 1,2,3 !!!
    {
        if (unlockedAb[IDSKILL - 1] == false)
        {
            unlockedAb[IDSKILL - 1] = true;
            lvlmng.lvlForUnblockSkills--;
            lvlmng.lvlForSkills--;
        }
        UnblockButton1.SetActive(false);
        UnblockButton2.SetActive(false);
        UnblockButton3.SetActive(false);
    }
    void Update()
    {
        if ((lvlmng.lvlForUnblockSkills != 0) && (lvlmng.lvlForSkills != 0))
        {
            if (unlockedAb[0] != true)
                UnblockButton1.SetActive(true);
            if (unlockedAb[1] != true)
                UnblockButton2.SetActive(true);
            if (unlockedAb[2] != true)
                UnblockButton3.SetActive(true);
            treeIsActive = true;
        }
        else
        {
            UnblockButton1.SetActive(false);
            UnblockButton2.SetActive(false);
            UnblockButton3.SetActive(false);
        }
        if (unlockedAb[0] == true)
            Skill1.interactable = true;
        if (unlockedAb[1] == true)
            Skill2.interactable = true;
        if (unlockedAb[2] == true)
            Skill3.interactable = true;
        if ((lvlmng.lvlForSkills != 0) && (unlockedAb[0] == true))
            LvlUpSkill1.SetActive(true);
        else
            LvlUpSkill1.SetActive(false);
        if ((lvlmng.lvlForSkills != 0) && (unlockedAb[1] == true))
            LvlUpSkill2.SetActive(true);
        else
            LvlUpSkill2.SetActive(false);
        if ((lvlmng.lvlForSkills != 0) && (unlockedAb[2] == true))
            LvlUpSkill3.SetActive(true);
        else
            LvlUpSkill3.SetActive(false);

        if (unlockedAb[0] == true)
            Img1Skill1Lvl.SetActive(true);
        if (levelAb[0] == 1)
            Img1Skill2Lvl.SetActive(true);
        if (levelAb[0] == 2)
        {
            Img1Skill2Lvl.SetActive(true);
            Img1Skill3Lvl.SetActive(true);
        }
        if (levelAb[0] == 3)
        {
            Img1Skill2Lvl.SetActive(true);
            Img1Skill3Lvl.SetActive(true);
            Img1Skill4Lvl.SetActive(true);
        }
        if (unlockedAb[1] == true)
            Img2Skill1Lvl.SetActive(true);
        if (levelAb[1] == 1)
            Img2Skill2Lvl.SetActive(true);
        if (levelAb[1] == 2)
        {
            Img2Skill2Lvl.SetActive(true);
            Img2Skill3Lvl.SetActive(true);
        }
        if (levelAb[1] == 3)
        {
            Img2Skill2Lvl.SetActive(true);
            Img2Skill3Lvl.SetActive(true);
            Img2Skill4Lvl.SetActive(true);
        }
        if (unlockedAb[2] == true)
            Img3Skill1Lvl.SetActive(true);
        if (levelAb[2] == 1)
            Img3Skill2Lvl.SetActive(true);
        if (levelAb[2] == 2)
        {
            Img3Skill2Lvl.SetActive(true);
            Img3Skill3Lvl.SetActive(true);
        }
        if (levelAb[2] == 3)
        {
            Img3Skill2Lvl.SetActive(true);
            Img3Skill3Lvl.SetActive(true);
            Img3Skill4Lvl.SetActive(true);
        }

    }
    public void SaveChanges() //сохранялка
    {
        //из переменных записать всё в объект класса и отправить/записать/ну хоть что-то сделать с этим....
        Debug.Log("ТИпо тут на сервак отправилось или что-то в этом роде... А пока 404. Will be added soon :)"); // СДЕЛАТЬ СОХРАНЯЛКУ!!!
        string first = levelAb[0].ToString();
        string second = levelAb[1].ToString();
        string third = levelAb[2].ToString();
        string grade = first + "-" + second + "-" + third;
        api.setLevelGrade(GlobalControl.Instance.email, GlobalControl.Instance.heroName, grade);

        api.setTreeGrade(GlobalControl.Instance.email, GlobalControl.Instance.heroName, GlobalControl.Instance.TreeGrade);
    }

}
