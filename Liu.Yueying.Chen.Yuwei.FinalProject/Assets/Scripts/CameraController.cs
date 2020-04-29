using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject thirdCam;
	public GameObject firstCam;
	public int camMode;  // 1 as first person, 3 as third person

	bool enterMouse;

	// Use this for initialization
	void Start () {
		camMode = 1;
	}
	
	// Update is called once per frame
	void Update () {
		enterMouse = player.GetComponent<PlayerController> ().enterMouse;
		if (Input.GetButtonDown ("Out")) {  // switch to first person camera
			if (camMode == 3) {
				camMode = 1;
				firstCam.SetActive (true); 
				thirdCam.SetActive (false);
				player.GetComponent<PlayerController> ().enterMouse = false;

			}
		}
		else if (enterMouse) {  // switch to third person camera
			if (camMode == 1) {
				camMode = 3;
				thirdCam.SetActive (true);
				firstCam.SetActive (false); 
			}
		}
	}
		
}
