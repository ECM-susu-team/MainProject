using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour {
	/*public static BaseObject Instance { get; private set;}

	public void Awake()
	{
		Instance = this;
	}*/

	protected string nameObject;
	protected float speed;
	protected float weight;

	public string GetName(){
		return nameObject;
	}
	public void SetName(string _name){
		nameObject = _name;
	}

	public float GetSpeed(){
		return speed;
	}
	public void SetSpeed(float _speed){
		speed = _speed;
	}

	public float GetWeight(){
		return weight;
	}
	public void SetWeight(float _weight){
		weight = _weight;
	}

}
