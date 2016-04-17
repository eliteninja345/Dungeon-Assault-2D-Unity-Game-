// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour 
{


	/* 

	Script Summary: 

	Allows the player to be damaged by enemies. Works with the PlayerHealthManager.cs
	
	*/ 

	public int damageToGive; 
	public GameObject damageNumber; 

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive); 
			// Instantiate (damageBurst, transform.position, transform.rotation);
			var clone = (GameObject)Instantiate (damageNumber, other.transform.position, Quaternion.Euler (Vector3.zero)); 
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive; 

		}
	}
}
