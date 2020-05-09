using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatScript : MonoBehaviour {
		
	public float moveSpeed = 2f;
	public float rotSpeed = 40f;
	private bool isWandering = false;
	private bool isRotatingLeft = false;
	private bool isRotatingRight = false;
	private bool isWalking = false;

	void Start()
	{
		
	}

	void Update()
	{
		if (isWandering == false)
		{
			StartCoroutine (Wander ());
		}
		if (isRotatingRight == true) 
		{
			transform.Rotate (transform.up * Time.deltaTime * rotSpeed);
		}
		if (isRotatingLeft == true) 
		{
			transform.Rotate (transform.up * Time.deltaTime * -rotSpeed);
		}
		if (isWalking = true)
		{
//			Debug.Log ("isWalking: " + isWalking);
			transform.position += transform.forward * moveSpeed;
//			Debug.Log ("postiion: " + transform.position.ToString ());
		}
	}

	IEnumerator Wander()
	{
		int rotTime = Random.Range (1, 5);
		int rotateWait = Random.Range (1, 4);
		int rotateLorR = Random.Range (1, 2);
		int walkWait = Random.Range (1, 4);
		int walkTime = Random.Range (1, 5);

		isWandering = true;

		yield return new WaitForSeconds (walkWait);
		isWalking = true;
		yield return new WaitForSeconds (walkTime);
		isWalking = false;
		yield return new WaitForSeconds (rotateWait);
		if (rotateLorR == 1) 
		{
			isRotatingRight = true;
			yield return new WaitForSeconds (rotTime);
			isRotatingRight = false;
		}
		if (rotateLorR == 2) 
		{
			isRotatingLeft = true;
			yield return new WaitForSeconds (rotTime);
			isRotatingLeft = false;
		}
		isWandering = false;
	}

//	NavMeshAgent navMeshAgent;
//	public float timerForNewPath;
//	bool inCoRoutine;
//
//	// Use this for initialization
//	void Start () 
//	{
//		navMeshAgent = GetComponent<NavMeshAgent> ();
//	}
//
//
//	Vector3 getNewRandomPosition() 
//	{
//		float x = Random.Range (-120, -100);
//		float z = Random.Range (-10, 20);
//
//		Vector3 pos = new Vector3 (x, 0, z);
//		return pos;
//	}
//
//	void Update()
//	{
//		if (!inCoRoutine) 
//		{
//			StartCoroutine (DoSomething ());
//		}
//	}
//
//
//	IEnumerator DoSomething()
//	{
//		inCoRoutine = true;
//		yield return new WaitForSeconds (timerForNewPath);
//		GetNewPath();
//		inCoRoutine = false;
//	}
//
//	void GetNewPath()
//	{
//		navMeshAgent.SetDestination (getNewRandomPosition ());
//	}
		
}
