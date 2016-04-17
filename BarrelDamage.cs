// What if I told you I like Metal Gear...?
// Put this script on the barrel. 
using UnityEngine;
using System.Collections;

public class BarrelDamage : MonoBehaviour 
{
	public int MaxHealth = 100; 
	public int CurrentHealth; 
	public GameObject item; 		// This could spawn in health, enemies, or money. 

	void Start ()
	{
		// At the start of our game, we want the current health of the barrel to equal the max health.
		CurrentHealth = MaxHealth; 
	}

	void Update ()
	{
		// If the barrel's current health is less than zero...
		if (CurrentHealth <= 0) 
		{
			// Remove it from the game. 
			Destroy (gameObject); 
			Instantiate (item, transform.position, transform.rotation); 
		}
	}

	public void HurtBarrel(int damageToGive)
	{
		CurrentHealth -= damageToGive; 
	}

	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth; 
	}



}
