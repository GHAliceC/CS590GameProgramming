using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
	public AudioClip mouse_sound;
	public AudioClip pick_sound;
	public AudioClip bomb_sound;
	public AudioClip music_daji_sound;
	public AudioClip music_zheng_sound;
	public AudioClip music_tanbo_sound;
	public AudioClip coffin_sound;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		source.PlayOneShot (coffin_sound);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "daji") {
			source.PlayOneShot (music_daji_sound);
		}

		if (other.gameObject.tag == "zheng") {
			source.PlayOneShot (music_zheng_sound);
		}

		if (other.gameObject.tag == "tanbo") {
			source.PlayOneShot (music_tanbo_sound);
		}
	}
}
