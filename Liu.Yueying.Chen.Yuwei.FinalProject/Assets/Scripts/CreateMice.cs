using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMice : MonoBehaviour {

	public GameObject mice_prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void instantiateMice () {
		Instantiate (mice_prefab);
	}
}
