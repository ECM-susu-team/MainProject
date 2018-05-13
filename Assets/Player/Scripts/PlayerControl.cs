using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	private float speed = 0f;
	private float JumpForce = 0f;
	private bool FaceToRight = true;
	private bool IsGround = false;
	private Rigidbody2D RB;

	public static GameObject weapon;
	GameObject WarriorClass;
	GameObject Skmngr;
	Warrior wrr;
    GameObject GameTree;
    TreeGrade treeGrade;

	private float NearWeaponDelay = 0f;

	void Awake(){
		RB = GetComponent<Rigidbody2D>();
	}
	void Start () {
		
		WarriorClass = GameObject.Find("character");
		wrr = WarriorClass.GetComponent<Warrior> ();

        GameTree = GameObject.Find("GameTree");
        treeGrade = GameTree.GetComponent<TreeGrade>();

		weapon = GameObject.Find ("ActivatedNearWeapon");


		JumpForce = wrr.GetJumpForce();//Warrior.Instance.GetJumpForce ();
		Debug.Log ("Jump Force for controller: " + JumpForce + " - success");
		speed = wrr.GetSpeed(); //Warrior.Instance.GetSpeed ();
		Debug.Log ("Speed for controller: " + speed + " - success");

        if (GlobalControl.Instance.TreeGrade == "1-1") treeGrade.InvokeRootNode();

        if (GlobalControl.Instance.TreeGrade == "2-1") treeGrade.InvokeNode2();

        if (GlobalControl.Instance.TreeGrade == "2-2") treeGrade.InvokeNode3();

        Debug.Log(GlobalControl.Instance.TreeGrade);

    }
	void FixedUpdate()
	{
		CheckGroung ();
		if (speed != wrr.GetSpeed ())
			speed = wrr.GetSpeed ();
		if(NearWeaponDelay == 0)
		{
			if (weapon != null)
			{
				weapon.SetActive(false);
			}
		}
		else 
			NearWeaponDelay -= 1;
		if (Input.GetButton ("Horizontal")) {
			Walk ();
			if (Input.GetKey(KeyCode.LeftShift))
				Run ();
		}
		if (IsGround && Input.GetKeyDown(KeyCode.Space))
			Jump ();
		if (Input.GetKeyDown(KeyCode.LeftControl) && NearWeaponDelay <= 10)
			Attack ();
	}

	void Update () {
		

	}
	private void Walk()
	{
		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed* Time.deltaTime);
		if (direction.x > 0 && !FaceToRight)
			flip ();
		else if (direction.x < 0 && FaceToRight)
			flip();

	}

	private void Run()
	{
		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, 1.5f*speed* Time.deltaTime);
		if (direction.x > 0 && !FaceToRight)
			flip ();
		else if (direction.x < 0 && FaceToRight)
			flip();
	}
	private void Jump()
	{
        //RB.AddForce (transform.up * JumpForce, ForceMode2D.Impulse);
        RB.AddForce(new Vector2(0, 1500));
	}
	private void Attack()
	{
        if(weapon != null)
        {
            weapon.SetActive(true);
            NearWeaponDelay = 30f;
        }
    }
	private void flip()
	{
		FaceToRight = !FaceToRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
	private void CheckGroung()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 1F);

		IsGround = colliders.Length > 1;
	}
}
