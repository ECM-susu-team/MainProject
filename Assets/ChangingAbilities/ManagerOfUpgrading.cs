using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerOfUpgrading : MonoBehaviour {

	GameObject WarriorClass;
	Warrior wrr;

	public Text Abil1;
	public Text Abil2;
	public Text Abil3;
	public Text PayLvl;
	public Text NickName;
	public Text TypeOfChar;

	bool[] unlockedAb;									//поля этого класса для работы
	int[] levelAb;
	int _level;

	void Start () {
		WarriorClass = GameObject.Find("character");
		wrr = WarriorClass.GetComponent<Warrior> ();

		unlockedAb = new bool[3];						//инициализация
		levelAb = new int[3];
		unlockedAb = wrr.unlockedabilities;
		levelAb = wrr.levelofabilities;
		_level = wrr.level;

		for (int i = 1; i <= 3; i++) {
			Print (i);
		}
		NickName.text = wrr.name;
		TypeOfChar.text = wrr.typeofcharacter;
	}
	void Update () {
		
	}
	private void Print (int _id)
	{
		if (_id == 1) {
			Abil1.text = "Speed(" + levelAb [_id - 1] + ")";
			if (unlockedAb [_id - 1] == false)
				Abil1.text += "\n (not unlocked)";
		}
		else if (_id == 2) {
			Abil2.text = "Invisibility(" + levelAb [_id - 1] + ")";
			if (unlockedAb [_id - 1] == false)
				Abil2.text += "\n (not unlocked)";
		}
		else if (_id == 3){
			Abil3.text = "Rage(" + levelAb [_id - 1] + ")";
			if (unlockedAb [_id - 1] == false)
				Abil3.text += "\n (not unlocked)";
		}
		PayLvl.text = "Level: " + _level;
	}
	public void Decrement (int IDSKILL)
	{
		if (unlockedAb [IDSKILL-1] == false)
			return;
		else {
			if (levelAb [IDSKILL - 1] > 0) {
				levelAb [IDSKILL - 1]--;
				_level++;
				Print (IDSKILL);
			}
			}
	}
	public void Increment (int IDSKILL)
	{
		if (unlockedAb [IDSKILL-1] == false)
			return;
		else {
			if (_level > 0) {
				levelAb [IDSKILL - 1]++;
				_level--;
				Print (IDSKILL);
			}
			else 
				PayLvl.text += "!";
			}
	}
	public void UnlockAbility(int IDSKILL)
	{
		if (unlockedAb [IDSKILL - 1] == false) {
			if (_level > 0) {
				unlockedAb [IDSKILL - 1] = true;
				_level--;
				Print (IDSKILL);
			}
		}
	}
	public void SaveChanges()
	{
		//из переменных записать всё в объект класса и отправить/записать/ну хоть что-то сделать с этим....
		Debug.Log ("ТИпо тут на сервак отправилось или что-то в этом роде... А пока 404. Will be added soon :)"); // СДЕЛАТЬ СОХРАНЯЛКУ!!!
	}
}
