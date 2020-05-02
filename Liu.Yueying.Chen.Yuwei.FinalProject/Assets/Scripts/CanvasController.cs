using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	// public game objects
	public GameObject player;
	public GameObject props_panel;
	public GameObject map;
	public GameObject instruction;
	public GameObject dagger_sprite;
	public GameObject jade_sprite;

	// public variable

	bool enterMouse;
	bool hasDagger;
	bool hasJade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		enterMouse = player.GetComponent<PlayerController> ().enterMouse;
		props_panel.SetActive (enterMouse);

		hasDagger = player.GetComponent<PlayerController> ().hasDagger;
		dagger_sprite.SetActive (hasDagger);

		hasJade = player.GetComponent<PlayerController> ().hasJade;
		jade_sprite.SetActive (hasJade);
		
	}

	public void onButtonCloseMapPressed(){
		map.SetActive (false);
	}

	public void onButtonCloseInstruPressed(){
		instruction.SetActive (false);
	}
}
