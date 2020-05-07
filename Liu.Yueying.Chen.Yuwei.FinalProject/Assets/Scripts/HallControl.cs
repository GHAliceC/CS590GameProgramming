using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HallControl : MonoBehaviour {

	public Text info_text;

	static public int death_type;

	// Use this for initialization
	void Start () {
		if (death_type == 1) {  // die for hitting exit fireballs
			info_text.text = "You died for being hit by exit fireballs!";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onButtonPlayPressed(){
		SceneManager.LoadScene (1);
	}

	public void onButtonStoryPressed(){
		info_text.text = "You are the soul of Viscount Jiaoye \n" +
			"having a lively body 500 BC \n" +
			"Now your body has become skeleton \n" +
			"You are FREE! \n" +
			"Get out of your mausoleum to be free!";
	}

	public void onButtonInstructionPressed(){
		info_text.text = "Use Up and Down arrow keys to move forward and back; \n" +
			"Use Left and Right arrow keys to turn left and right; \n" +
			"There are many ways you can die; \n" +
			"But you can get out once you stop the fire balls at the entrance; \n" +
			"There are some props in the mausoleum that you can collect to help you reach you goal, \n" +
			"but you need to embody something to take objects.";
	}
}
