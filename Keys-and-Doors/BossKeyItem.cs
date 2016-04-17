// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class BossKeyItem : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the game object name is equal to "Player", 
		if (collider.gameObject.name == "Player") 
		{
			// Adds a count of one to the keyCount. Makes it so when we pick up one key, we can only open up one door. 
			// We were used to be able to open up two doors with one key. Now it's one key, one door. 
			GameVariables.bossKeyCount+=1;
			Destroy (gameObject); 
		}
	}
}
