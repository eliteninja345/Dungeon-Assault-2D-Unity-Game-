// What if I told you I like Metal Gear...?
// Put this script on both arrow bottom/top (clone). 
using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour 
{
	public int damageToGive; 			// Sets how much damage we want to do to the enemy. 

	public GameObject damageBurst; 		// Calls out the damageBurst particle effect. 
	public GameObject damageBurst2;
	public Transform hitPoint; 			
										/* Used for melee systems as we want the damageBurst
										 particle effect to happen on the tip of the weapon */ 
	public GameObject damageNumber; 

	public void damageAmount(int currentDamage)
	{
		damageToGive = currentDamage; 
	}
		
	void OnTriggerEnter2D (Collider2D other)
	{
		
			// Checks if the tag is listed as 'Enemy'. 
		if (other.gameObject.tag == "Enemy") 
		{
			// Accesses the enemyDamage.cs script. 
			other.gameObject.GetComponent<enemyDamage> ().HurtEnemy (damageToGive);  
			// Spawns the damageBurst prefab the moment the arrow hits an enemy. 
			Instantiate (damageBurst, transform.position, transform.rotation);

			// If the player attack is melee, use this instead:  
			// Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);

			/* var is the shorthand term for variable. It is a blank variable that Unity kinda knows that we are 
			going to create something, we don't know yet. */
			var clone = (GameObject)Instantiate (damageNumber, transform.position, Quaternion.Euler (Vector3.zero)); 
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive; 
			// Debug.Log ("Floating Numbers"); 

			// Destroy the arrow upon hitting the 'Enemy' tag. 
			Destroy (gameObject); 
		} 

		else if (other.gameObject.tag == "Boss") 
		{
			// Access the bossHealth script. 
			other.gameObject.GetComponent<bossHealth> ().HurtEnemy (damageToGive);  
			Instantiate (damageBurst, transform.position, transform.rotation);
			var clone = (GameObject)Instantiate (damageNumber, transform.position, Quaternion.Euler (Vector3.zero)); 
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
			Destroy (gameObject); 
		}

		// These are barrels and such. 
		else if (other.gameObject.tag == "Destructibles") 
		{
			// Accesses the BarrelDamage.cs script. 
			other.gameObject.GetComponent<BarrelDamage> ().HurtBarrel (damageToGive); 
			Instantiate (damageBurst2, transform.position, transform.rotation); 
			var clone = (GameObject)Instantiate (damageNumber, transform.position, Quaternion.Euler (Vector3.zero)); 
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive; 
			Destroy (gameObject); 
		}
	}
		
	// What happens to the arrow when it hits the wall. 

	void OnCollisionEnter2D (Collision2D collision1)
	{
		// Change the tags, just don't use Finish mkay? 
		if (collision1.gameObject.tag == "Finish") 
		{
			// Change the arrow hit boxes. 
			Destroy (gameObject.GetComponent<Collider2D>(), 0.1f); 
			Destroy (GetComponent<attackTrigger>()); 
		}
	}

}
