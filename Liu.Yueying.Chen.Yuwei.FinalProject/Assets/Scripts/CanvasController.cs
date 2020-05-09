using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

	// public game objects
	public GameObject player;
	public GameObject props_panel;
	public GameObject map;
	public GameObject instruction;
	public GameObject dagger_sprite;
	public GameObject jade_sprite;
	public GameObject bowl_sprite;
	public GameObject wine_sprite;
	public GameObject explosion;
	public GameObject explosion_ball;
	public GameObject wine_door;
	public GameObject kitchen_door;



	// private variable

	bool enterMouse;
	bool hasDagger;
	bool hasJade;
	bool explosionReady;
	float explosionTime;
	bool hasBowl;
	bool hasWine;
	bool exploded;

	// Use this for initialization
	void Start () {
		explosionTime = 10f;
		exploded = false;
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
//		Debug.Log (explosionReady);

		if (explosionReady && !exploded) {
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
				exploded = true;
				AudioSource source = player.GetComponent<SoundController> ().source;
				AudioClip boom = player.GetComponent<SoundController> ().bomb_sound;
				source.PlayOneShot (boom);
				bool safe = player.GetComponent<PlayerController> ().is_safe;
				if (safe) {
					explosion.SetActive (false);
					explosion_ball.SetActive (false);
					wine_door.SetActive (false);
					kitchen_door.SetActive (false);
				} else {
					HallControl.death_type = 4;
					SceneManager.LoadScene (0);
				}
			}
		}

		hasBowl = player.GetComponent<PlayerController> ().hasBowl;
		bowl_sprite.SetActive (hasBowl && !hasWine);
		hasWine = player.GetComponent<PlayerController> ().hasWine;
		wine_sprite.SetActive (hasBowl && hasWine);
	}

	public void onButtonCloseMapPressed(){
		map.SetActive (false);
	}

	public void onButtonCloseInstruPressed(){
		instruction.SetActive (false);
	}
}
