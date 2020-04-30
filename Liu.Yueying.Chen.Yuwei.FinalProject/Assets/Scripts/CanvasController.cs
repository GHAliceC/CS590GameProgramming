using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	// public game objects
	public GameObject player;
	public GameObject props_panel;
	public GameObject map;
	public GameObject instruction;

	// public variable

	bool enterMouse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		enterMouse = player.GetComponent<PlayerController> ().enterMouse;
		props_panel.SetActive (enterMouse);
		
	}

	public void onButtonCloseMapPressed(){
		map.SetActive (false);
	}

	public void onButtonCloseInstruPressed(){
		instruction.SetActive (false);
	}
}
