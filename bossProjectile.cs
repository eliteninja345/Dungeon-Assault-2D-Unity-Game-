// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class bossProjectile : MonoBehaviour 
{
	public int damageToGive; 
	public GameObject damageNumber; 
	public GameObject damageBurst; 		


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive); 

			// Spawns the damageBurst prefab the moment the arrow hits an enemy. 
			Instantiate (damageBurst, transform.position, transform.rotation);

			/* var is the shorthand term for variable. It is a blank variable that Unity kinda knows that we are 
			going to create something, we don't know yet. */
			var clone = (GameObject)Instantiate (damageNumber, other.transform.position, Quaternion.Euler (Vector3.zero)); 
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive; 
			// Debug.Log ("Floating Numbers"); 

			// Destroy the arrow upon hitting the 'Enemy' tag. 
			Destroy (gameObject); 
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Finish")
		{
			// Destroy (gameObject); 
			Destroy (gameObject.GetComponent<Collider2D>(), 0.1f); 
		}
	}
}
