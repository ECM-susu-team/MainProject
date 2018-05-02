using UnityEngine;

public class ButtonsSkills : MonoBehaviour {

    GameObject WarriorClass;
    Warrior wrr;
    public float speed;

    void Start () {
        WarriorClass = GameObject.Find("character");
        wrr = WarriorClass.GetComponent<Warrior>();
    }
	
	public void FirstSkill()
    {
        wrr.SetSpeed(20);
    }
    public void SecondSkill()
    {

    }
}
