// What if I told you I like Metal Gear...?
using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthToGive; 

	void OnTriggerEnter2D (Collider2D other)
	{
		// Checks if this is the player controller script (Movement.cs). 
		if (other.GetComponent<Movement> () == null)
			// If not the player, return this. This way, we don't have to worry about the enemy picking it up. 
			return; 
		// Grabbing the PlayerHealthManager script. 
		other.gameObject.GetComponent<PlayerHealthManager>().HealPlayer (healthToGive); 
		// PlayerHealthManager.HealPlayer(+healthToGive); 
		Destroy (gameObject); 
	}
}
