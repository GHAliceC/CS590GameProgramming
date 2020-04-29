using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// This script should be attached to the mouse that the player controls
	// Also, add CharacterController component on the mouse

	public bool enterMouse;
	public GameObject canvas_prop;
	public GameObject[] dagger_block;
	public GameObject[] jade_block;
	public GameObject warning;

	float moveSpeed;
	float turnSpeed;
	CharacterController controller;
	Vector3 rotation;
	bool hasDagger;
	bool hasJade;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		moveSpeed = 200f;
		turnSpeed = 100f;
		enterMouse = false;
		hasDagger = false;
		hasJade = false;
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

		// toggle prop on canvas
		if (enterMouse && !canvas_prop.activeSelf) {
			canvas_prop.SetActive (true);
		}
		if (!enterMouse && canvas_prop.activeSelf) {
			canvas_prop.SetActive (false);
		}

		// remove invisible doors when conditions are reached
		if (hasDagger && !enterMouse) {
			foreach (GameObject invisDoor in dagger_block) {
				invisDoor.SetActive (false);
			}
		}
		if (hasJade || !enterMouse) {
			foreach (GameObject invisDoor in jade_block) {
				invisDoor.SetActive (false);
			}
		}else if (!hasJade && enterMouse){
			foreach (GameObject invisDoor in jade_block) {
				invisDoor.SetActive (true);
			}
		}

	}

	void OnTriggerEnter(Collider other){
		// enter mouse
		if(other.gameObject.tag == "mouse"){
			enterMouse = true;
		}

		// Entertainment, Library and Clothing doors
		if (other.gameObject.tag == "door_normal") {
			if (enterMouse) {
				other.gameObject.SetActive (false);
			}
		}

		// Weapon and Music doors
		if (other.gameObject.tag == "door_jade") {
			if (enterMouse && !hasJade) { //door not open
				warning.SetActive(true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text>().text = "You cannot enter this door in a mouse yet!";
				StartCoroutine (RemoveWarning ());
			}
		}

		if (other.gameObject.tag == "door_dagger") {
			if (!hasDagger) {
				warning.SetActive(true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text>().text = "You cannot enter this door yet!";
				StartCoroutine (RemoveWarning ());
			}
		}
			
	}

	IEnumerator RemoveWarning()
	{
		yield return new WaitForSeconds(5);
		warning.SetActive(false);
	}
		
}
