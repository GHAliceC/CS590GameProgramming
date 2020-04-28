using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// This script should be attached to the mouse that the player controls
	// Also, add CharacterController component on the mouse

	public bool enterMouse;

	float moveSpeed;
	float turnSpeed;
	CharacterController controller;
	Vector3 rotation;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		moveSpeed = 200f;
		turnSpeed = 100f;
		enterMouse = false;
	}
	
	// Update is called once per frame
	void Update () {
		// move forward
		Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
		move = this.transform.TransformDirection(move);
		controller.Move(move * moveSpeed);
		// turn left and right
		rotation = new Vector3 (0, Input.GetAxisRaw ("Horizontal") * turnSpeed * Time.deltaTime, 0);
		this.transform.Rotate(rotation);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "mouse")
		{
//			Debug.Log ("enter mouse");
			enterMouse = true;
		}
	}
		
}
