using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour {
	int Skill_ID = 0;
	int Last_Skill_ID = 0;
	float skillTimer = 0f;
	float SpeedOfObject;
	int DamageOfObject;

	GameObject WarriorClass;
	Warrior wrr;
	GameObject SpeedParticle;
	GameObject BurningNearWeapon;
	void Start () {
		WarriorClass = GameObject.Find("character");
		wrr = WarriorClass.GetComponent<Warrior> ();
		SpeedParticle = GameObject.Find ("SpeedParticle");
		SpeedParticle.SetActive (false);
		BurningNearWeapon = GameObject.Find ("BurningNearWeapon");
		BurningNearWeapon.SetActive (false);
	}
	public void Set_ID(int id)
	{
		Skill_ID = id;
		Last_Skill_ID = Skill_ID;
	}
	void FixedUpdate () {
		if (skillTimer > 0) {
			skillTimer -= Time.deltaTime;
		}
		else if (skillTimer < 0) {
			skillTimer = 0;
			if (Last_Skill_ID==1)
				TurnOffSpeed ();
			else if (Last_Skill_ID == 3)
				TurnOffRage ();
		}
		else if(skillTimer == 0)
		{
			if (Skill_ID == 1)
				TurnOnSpeed ();
			else if (Skill_ID == 2)
				Debug.Log ("2 SKILL");
			else if (Skill_ID == 3)
				TurnOnRage ();
			Skill_ID = 0;
		}
	}

	void TurnOnSpeed()
	{
		SpeedOfObject = wrr.GetSpeed();
		wrr.SetSpeed (SpeedOfObject * 2f);
		skillTimer = 5f;
		SpeedParticle.SetActive (true);
	}
	void TurnOffSpeed()
	{
		wrr.SetSpeed (SpeedOfObject);
		SpeedParticle.SetActive (false);
	}

	void TurnOnRage()
	{
		DamageOfObject = wrr.pdamage;
		wrr.pdamage = DamageOfObject + 60; // ДОРАБОТАТЬ В ПРОЦЕССЕ!!!
		skillTimer = 3f;
		BurningNearWeapon.SetActive (true);
	}
	void TurnOffRage()
	{
		wrr.pdamage = DamageOfObject;
		BurningNearWeapon.SetActive (false);
	}
}