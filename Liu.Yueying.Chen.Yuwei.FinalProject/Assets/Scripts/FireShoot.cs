using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShoot : MonoBehaviour {

	public float speed = 20;
	public float fireRate = 4;

	public ParticleSystem fireFlash;

	private float nextTimeToFire = 0;
	// Use this for initialization
	void Start () {
		if (Input.GetKeyDown ("space") && Time.time >= nextTimeToFire) {
			nextTimeToFire = Time.time + 1 / fireRate;
			Shoot ();
		}

	}
	
	// Update is called once per frame
	void Shoot() {
		if (speed != 0) {
			transform.position += new Vector3(0, 0, 0.1f * (speed * Time.deltaTime));
		} else {
			Debug.Log ("No speed!");
		}
	}
}
