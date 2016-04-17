using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget; 

	// When we hit a box collision that has a trigger turned on... 
	void OnTriggerEnter2D(Collider2D other)
	{
		// 
		if (other.gameObject.name == "Player") 
		{
			// Debug.Log ("LEGEND OF ZELDA"); 
			other.gameObject.transform.position = warpTarget.position; 
		}

		// If the camera if fixed, this will teleport to the player's location. 
		// Camera.main.transform.position = warpTarget.position; 
	}
}
