using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Warrior : SomeCharacter {
	Skills SkillsObject;
	void Awake () {
		SkillsObject = new Skills ();
		StreamReader StrRdr = new StreamReader ("Assets\\Data\\Skills.json");
		string jsonStr = StrRdr.ReadToEnd ();
		JsonUtility.FromJsonOverwrite (jsonStr, SkillsObject);
		maxHealth = SkillsObject.Max_HP;
		curHealth = maxHealth;
		pdamage = 50;
		level = SkillsObject.Level;
		jumpForce = SkillsObject.Jump_Force;
		speed = SkillsObject.Speed;
		weight = SkillsObject.Weight;
		nameObject = SkillsObject.NickName;
		pXP = 0;

		UnlockedAbilities = new bool[3];
		LevelOfAbilities = new int[3];

		for (int i = 0; i < UnlockedAbilities.Length; i++) {
			UnlockedAbilities [i] = SkillsObject.UnlockedSkills [i];
		}
		for (int i = 0; i < LevelOfAbilities.Length; i++) {
			LevelOfAbilities [i] = SkillsObject.LevelsOfSkills [i];
		}
		TypeOfCharacter = SkillsObject.TypeOfCharacter;

		Debug.Log ("Characteristics: HP - " + maxHealth + " JF - " + jumpForce + " SPD - " + speed + " WGHT - " + weight + " NM - " + nameObject + " LVL - " + level + "UnlockedAbil - " + UnlockedAbilities[1] + "LevelOfAbil" + LevelOfAbilities[1]);
	}
	public override void DamagePlayer(int damage)
	{
		base.DamagePlayer(damage);
	}
}
