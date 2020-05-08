using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour {

//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	void Update() {
//		transform.Rotate(Vector3.down * Time.deltaTime * 100);
//		if (Input.GetKeyDown ("space")) {
		transform.Rotate (0, 0, 1f);
		if (transform.localRotation.z <= -40) {
			transform.Rotate (0, 0, 1.0f * Time.deltaTime * 100);
		}

		if (transform.localRotation.z >= 40) {
			transform.Rotate (0, 0, -1.0f * Time.deltaTime * 100);
		}

//		}
	}

}
