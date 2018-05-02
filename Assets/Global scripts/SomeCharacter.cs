using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeCharacter : BaseObject {
	protected int health;
	protected float jumpForce;
	protected int _level;
	protected bool[] UnlockedAbilities;
	protected int[] LevelOfAbilities;
	protected string TypeOfCharacter;
	int _pdamage;
	private float _maxHealth;
	private float _curHealth;
	private float _pXP;

	public bool[] unlockedabilities
	{
		get { return UnlockedAbilities;}
		set { UnlockedAbilities = value;}
	}
	public int[] levelofabilities
	{
		get { return LevelOfAbilities;}
		set { LevelOfAbilities = value;}
	}
	public string typeofcharacter
	{
		get { return TypeOfCharacter; }
		set { TypeOfCharacter = value; }
	}

	public int level
	{
		get { return _level; }
		set { _level = value; }
	}


	public int pdamage
	{
		get { return _pdamage; }
		set { _pdamage = value; }
	}


	public float maxHealth
	{
		get { return _maxHealth; }
		set { _maxHealth = value; }
	}


	public float curHealth
	{
		get { return _curHealth; }
		set { _curHealth = Mathf.Clamp(value, 0, _maxHealth); }
	}


	public float pXP
	{
		get { return _pXP; }
		set { _pXP = value; }
	}

	public float GetJumpForce() { return jumpForce;}
	public void SetJumpForce (float _force) { jumpForce = _force;}

	public void KillPlayer(SomeCharacter other)
	{
		Destroy(other.gameObject);
	}
	public virtual void DamagePlayer(int damage)
	{

		if (_curHealth <= 0 && gameObject.tag == "Enemy")
		{
			KillPlayer(this);
		}
		else
		{
			_curHealth -= damage;
		}
	}



}
