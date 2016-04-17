// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

	public float timeToDestroy; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Substracts timeToDestroy from Time.deltaTime
		timeToDestroy -= Time.deltaTime; 

		// Since we set the time for timeToDestroy to 1.5, if that reaches zero...
		if (timeToDestroy <= 0) 
		{
			// Remove the gameObject from the scene. 
			Destroy (gameObject); 
		}
	}
}
