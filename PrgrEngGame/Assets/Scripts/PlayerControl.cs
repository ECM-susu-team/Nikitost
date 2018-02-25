using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	private float speed = 0f;
	private float JumpForce = 0f;
	private bool FaceToRight = true;

	private Rigidbody2D RB;

	void Awake(){
		RB = GetComponent<Rigidbody2D>();
	}
	void Start () {

		GameObject WarriorClass = GameObject.Find("character");
		Warrior wrr = WarriorClass.GetComponent<Warrior> ();

		JumpForce = wrr.GetJumpForce();//Warrior.Instance.GetJumpForce ();
		Debug.Log ("Jump Force for controller: " + JumpForce + " - success");
		speed = wrr.GetSpeed(); //Warrior.Instance.GetSpeed ();
		Debug.Log ("Speed for controller: " + speed + " - success");
	}

	void Update () {
		if (Input.GetButton ("Horizontal"))
			Run ();
		if (Input.GetButtonDown("Jump"))
			Jump ();
		
	}
	void Run()
	{
		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed* Time.deltaTime);
		if (direction.x > 0 && !FaceToRight)
			flip ();
		else if (direction.x < 0 && FaceToRight)
			flip();

	}
	void Jump()
	{
		RB.AddForce (transform.up * JumpForce, ForceMode2D.Impulse);
	}
	void flip()
	{
		FaceToRight = !FaceToRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
}
