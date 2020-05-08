using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatScript : MonoBehaviour {

	private NavMeshAgent nma = null;
	private GameObject[] RandomPoint;
	private Transform target;
	private Vector3 dest;
	private int CurrentRandom;

	// Use this for initialization
	void Start () {
		nma = this.GetComponent<NavMeshAgent> ();
		target = this.transform;
		RandomPoint = GameObject.FindGameObjectsWithTag ("RandomPoint");
//		Debug.Log ("RandomPoints = " + RandomPoint.Length.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		if (nma.hasPath == false) {
			float distance = Vector3.Distance(target.position, transform.position);

			if (distance <= 0.1f)
			{
				nma.SetDestination(target.position);
			}
			CurrentRandom = Random.Range (0, RandomPoint.Length);
			nma.SetDestination (RandomPoint [CurrentRandom].transform.position);
//			dest = RandomPoint [CurrentRandom].transform.position;
//			transform.position = Vector3.Lerp (target.position, dest, 5f*Time.deltaTime);
//			Debug.Log ("current " + target.position.ToString ());
//			Debug.Log ("Moving" + RandomPoint [CurrentRandom].transform.position.ToString ());
		}
	}
}
