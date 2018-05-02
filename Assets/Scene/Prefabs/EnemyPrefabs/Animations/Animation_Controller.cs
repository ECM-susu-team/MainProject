using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour {
	private Animator animator;

	private StateOfAnim State
	{
		get { return (StateOfAnim)animator.GetInteger  ("State");}
		set { animator.SetInteger ("State", (int)value);}
	}
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	void Start () {
	}
	void Update () {
	}
	void OnEnable(){
		gEnemyAI.OnAttack += Attack;
		gEnemyAI.OnDisableAttack += Flight;
	}
	void OnDisable(){
		gEnemyAI.OnAttack -= Attack;
		gEnemyAI.OnDisableAttack -= Flight;
	}
	void Attack(){
		State = StateOfAnim.Attack;
	}
	void Flight(){
		State = StateOfAnim.Flight;
	}
}
public enum StateOfAnim
{ Flight, Attack }