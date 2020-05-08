using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	// This script should be attached to the mouse that the player controls
	// Also, add CharacterController component on the mouse

	public GameObject canvas_prop;
	public GameObject[] dagger_block;
	public GameObject[] jade_block;
	public GameObject warning;
	public GameObject map;
	public GameObject instruction;
	public GameObject jade;
//	public GameObject fan;
//	public GameObject seesaw;
//	public GameObject fire;
//	public ParticleSystem fireball;
	public GameObject exit_block;

	public bool enterMouse;
	public bool hasDagger;
	public bool hasJade;
	public bool explodeReady;
	public bool hasBowl;
	public bool hasWine;

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
		hasDagger = false;
		hasJade = false;
		explodeReady = false;
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
		} else {
			foreach (GameObject invisDoor in dagger_block) {
				invisDoor.SetActive (true);
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
				Debug.Log("here");
				warning.SetActive (true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text> ().text = "You cannot enter this door in a mouse yet!";
				StartCoroutine (RemoveWarning ());
			} else if (enterMouse && hasJade) {  // can open door
				other.gameObject.SetActive (false);
			}  // else !enterMouse -> just go through door
		}
		// Kitchen and Wine doors
		if (other.gameObject.tag == "door_dagger") {
			if (!hasDagger) {
				warning.SetActive (true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text> ().text = "You cannot enter this door yet!";
				StartCoroutine (RemoveWarning ());
			} else {  // has dagger
				if (enterMouse) {
					warning.SetActive (true);
					GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
					warning_text.GetComponent<Text> ().text = "Dagger opend a small slit which a mouse cannot pass! ";
					StartCoroutine (RemoveWarning ());
				} else {
					warning.SetActive (true);
					GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
					warning_text.GetComponent<Text> ().text = "Dagger opend a small slit which a soul can pass! ";
					StartCoroutine (RemoveWarning ());
				}
			}
		}

		// UI
		if (other.gameObject.name == "map_trigger") {
			map.SetActive (true);
		}

		if (other.gameObject.name == "instru_trigger") {
			instruction.SetActive (true);
		}

		// pick up dagger
		if (other.gameObject.tag == "dagger") {
			if (!hasDagger) {  // only triggers event if not have dagger
				if (!enterMouse) {  // cannot pickup dagger if not in mouse
					warning.SetActive (true);
					GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
					warning_text.GetComponent<Text> ().text = "You cannot pickup anything as a soul!";
					StartCoroutine (RemoveWarning ());
				} else {  // pick up dagger
					hasDagger = true;
					warning.SetActive (true);
					GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
					warning_text.GetComponent<Text> ().text = "Congrats! You obtained a dagger.";
					StartCoroutine (RemoveWarning ());
				}
			}
		}

		// pick up jade
		if (other.gameObject.name == "jade") {
			if (!hasJade) {  // only triggers event if not have jade
				if (!enterMouse) {  // cannot pickup jade if not in mouse
					warning.SetActive (true);
					GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
					warning_text.GetComponent<Text> ().text = "You cannot pickup anything as a soul!";
					StartCoroutine (RemoveWarning ());
				} else {
					hasJade = true;
					jade.SetActive (false);
					warning.SetActive (true);
					GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
					warning_text.GetComponent<Text> ().text = "Congrats! You obtained a jade.";
					StartCoroutine (RemoveWarning ());
				}
			}
		}

		// touch light
		if (other.gameObject.tag == "light") {
			explodeReady = true;
		}

		// take bowl
		if (other.gameObject.tag == "bowl") {
			if (enterMouse) {
				hasBowl = true;
				warning.SetActive (true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text> ().text = "Congrats! You obtained a bowl.";
				StartCoroutine (RemoveWarning ());
			} else {
				warning.SetActive (true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text> ().text = "You cannot pickup anything as a soul!";
				StartCoroutine (RemoveWarning ());
			}
		}

		// take wine
		if (other.gameObject.tag == "wine") {
			if (enterMouse && hasBowl) {
				hasWine = true;
				warning.SetActive (true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text> ().text = "Congrats! You obtained a bowl of alcohol.";
				StartCoroutine (RemoveWarning ());
			}
		}

		// add wine
		if (other.gameObject.name == "mice_bowl_trigger") {
			if (hasWine) {
				exit_block.SetActive (false);
				warning.SetActive (true);
				GameObject warning_text = warning.transform.Find ("Warning_text").gameObject;
				warning_text.GetComponent<Text> ().text = "Mice are drunk!";
				StartCoroutine (RemoveWarning ());
//				StopFire ();
			}
		}

		if (other.gameObject.name == "death_exit") {
			HallControl.death_type = 1;
			SceneManager.LoadScene (0);
		}
	}

	IEnumerator RemoveWarning()
	{
		yield return new WaitForSeconds(5);
		warning.SetActive(false);
	}

	// stop fire shooting
//	void StopFire() {
//		fan = GameObject.Find ("Fan");
//		fan.transform.Rotate (0f, 0f, 0f);
//		fire = GameObject.Find ("Fire");
//		fireball  = fire.GetComponentInChildren <ParticleSystem> ();
//		seesaw = GameObject.Find ("Seesaw");
//		fireball.Stop ();
//	}
		
}
