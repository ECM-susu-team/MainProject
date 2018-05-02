using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

	private Animator animator;
	public GameObject thisObject;
	private float Xcoord;
	private float Ycoord;

	private bool IsGround = false;
	//private SpriteRenderer sprite;
	private CHState State
	{
		get { return (CHState)animator.GetInteger  ("State");}
		set { animator.SetInteger ("State", (int)value);}
	}
    void Awake(){
		animator = GetComponent<Animator> ();
		Xcoord = thisObject.transform.position.x;
		Ycoord = thisObject.transform.position.y;
	}
	void Start () {
		
	}
	void FixedUpdate()
	{
		CheckGroung ();
	}
	void Update () {
		State = CHState.Stand;
		//Vector3 direction = transform.right * Input.GetAxis ("Horizontal");

		if (Input.GetButton ("Horizontal")) // (Xcoord != thisObject.transform.position.x)
		{
			State = CHState.Walk;
			if (Input.GetKey (KeyCode.LeftShift))
				State = CHState.Run;
		}
		else //if (direction.x == 0)
		{
			State = CHState.Stand;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			State = CHState.Jump;
		}
        if (Input.GetKeyDown(KeyCode.LeftControl))//(Input.GetKey(KeyCode.LeftControl))
        {
            State = CHState.Attack;
        }
		
		Xcoord = thisObject.transform.position.x;
	}
	private void CheckGroung()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 0.5F);

		IsGround = colliders.Length > 2;
	}
}
public enum CHState
{ Stand, Walk, Run, Jump, Attack }