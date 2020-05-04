using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	// public game objects
	public GameObject player;
	public GameObject props_panel;
	public GameObject map;
	public GameObject instruction;
	public GameObject dagger_sprite;
	public GameObject jade_sprite;
	public GameObject explosion;
	public GameObject explosion_ball;



	// public variable

	bool enterMouse;
	bool hasDagger;
	bool hasJade;
	bool explosionReady;
	float explosionTime;

	// Use this for initialization
	void Start () {
		explosionTime = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		enterMouse = player.GetComponent<PlayerController> ().enterMouse;
		props_panel.SetActive (enterMouse);

		hasDagger = player.GetComponent<PlayerController> ().hasDagger;
		dagger_sprite.SetActive (hasDagger);

		hasJade = player.GetComponent<PlayerController> ().hasJade;
		jade_sprite.SetActive (hasJade);

		explosionReady = player.GetComponent<PlayerController> ().explodeReady;

		if (explosionReady) {
			explosionTime -= Time.deltaTime;
			GameObject explosion_text = explosion.transform.Find ("Explosion").gameObject;
			explosion_text.GetComponent<Text> ().text = "Explosion!!! \n Please leave this room in " + (explosionTime).ToString("0") + " seconds!";
			if (!explosion.activeSelf) {
				explosion.SetActive (true);
				explosion_ball.SetActive (true);
			}

			explosion_ball.SetActive (true);
			explosion_ball.transform.localScale += 50 * Time.deltaTime * new Vector3 (1f, 1f, 1f);

			if (explosionTime < 0)
			{
				explosion.SetActive (false);
				explosion_ball.SetActive (false);
			}
		}
		
	}

	public void onButtonCloseMapPressed(){
		map.SetActive (false);
	}

	public void onButtonCloseInstruPressed(){
		instruction.SetActive (false);
	}
}
