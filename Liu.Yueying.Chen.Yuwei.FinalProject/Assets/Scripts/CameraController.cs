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
//		Debug.Log (camMode);
		enterMouse = player.GetComponent<PlayerController> ().enterMouse;
//		Debug.Log (enterMouse);
		if (Input.GetButtonDown ("Out")) {
			if (camMode == 3) {
				camMode = 1;
				Debug.Log (camMode);
				Debug.Log ("switch to first");
				firstCam.SetActive (true); 
				thirdCam.SetActive (false);
				player.GetComponent<PlayerController> ().enterMouse = false;

			}
		}
		else if (enterMouse) {
//			Debug.Log (camMode);
			if (camMode == 1) {
				camMode = 3;
				Debug.Log ("switch to third");
				thirdCam.SetActive (true);
				firstCam.SetActive (false); 
			}
		}
	}
		
}
