using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bars : MonoBehaviour {

    private float curHP = 0f;
    private float curEXP = 1f;
    private int curLVL = 1;
    public GameObject barHP;
    public GameObject barEXP;
    public Text LVLIndicator, CurrentEXP, AmountOfEXP;
    GameObject WarriorClass, LvlManagerClass;
    Warrior wrr;
    LvlManager lvlmng;
    void Start()
    {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();

        LvlManagerClass = GameObject.Find("Main Camera");
        lvlmng = LvlManagerClass.GetComponent<LvlManager>();
    }

    void Update () {
        if (curHP != wrr.curHealth)
        {
            curHP = wrr.curHealth; //Warrior.Instance.GetHealth ();
            if (curHP <= 0)
                SceneManager.LoadScene("Scene1");
            Debug.Log("HP for controller: " + curHP + " - success");
            barHP.transform.localScale = new Vector3(curHP / 100, 1, 1);
        }
        if (curEXP != wrr.pXP)
        {
            curEXP = wrr.pXP; //Warrior.Instance.GetEXP ();
            Debug.Log("EXP for controller: " + curEXP + " - success");
            barEXP.transform.localScale = new Vector3(curEXP / 100, 1, 1);
            CurrentEXP.text = curEXP.ToString();
            AmountOfEXP.text = lvlmng.GetNextLvl.ToString();
        }
        if (curLVL != wrr.level)
        {
            curLVL = wrr.level;//Warrior.Instance.GetLevel ();
            Debug.Log("LVL for controller: " + curLVL + " - success");
            LVLIndicator.text = curLVL.ToString();
        }
    }
}
