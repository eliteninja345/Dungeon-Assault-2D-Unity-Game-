// What if I told you I like Metal Gear...?
using UnityEngine;
using System.Collections;

public class KeyItem : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the game object name is equal to "Player", 
		if (collider.gameObject.name == "Player") 
		{
			// Adds a count of one to the keyCount. Makes it so when we pick up one key, we can only open up one door. 
			GameVariables.keyCount+=1;
			// Remove the next line down after we get the key counter working. 
			// GameVariables.keyDisplayTime = 2; 
			Destroy (gameObject); 
		}
	}
}
