using UnityEngine;
using System.Collections;

public class KeyGate : MonoBehaviour {

	public GameObject gate; 
	 
	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the game object name is player and we have more than 0 keys, 
		if (collider.gameObject.name == "Player" && GameVariables.keyCount > 0) 
		{
			// Decrease our key count by one. 
			GameVariables.keyCount--;
			Destroy (gameObject); 
			Destroy (gate); 
		
		}
	}

}
