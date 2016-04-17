// What if I told you I like Metal Gear...?
// Put this script onto the enemy. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class enemyDamage : MonoBehaviour 
{
	// Health 
	public int MaxHealth ; 
	public int CurrentHealth; 

	// Drop chance of money
	public GameObject bronzeCoin;
	public GameObject silverCoin;
	public GameObject goldCoin;
	public int dropChanceRange;
	public int dropChanceNumber; 



	void Start ()
	{
		// At the start of our game, we want the current health of the enemy to equal the max health.
		CurrentHealth = MaxHealth; 

	}

	void Update ()
	{
		// If the enemy's current health is less than zero...
		if (CurrentHealth <= 0) 
		{
			// Calls out the dropChanceCalculator function. 
			dropChanceCalculator (); 
			// Remove it from the game. 
			Destroy (gameObject); 
		}
	}

	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive; 

			
	}

	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth; 
	}

	// Chance of the enemy dropping some money. 
	public void dropChanceCalculator() 
	{
		dropChanceRange = Random.Range (0, 101); 
		dropChanceNumber = dropChanceRange; 

		// If the dropChanceNumber is greater or equal to 10....
		if (dropChanceNumber >= 60) 
		{
			bronzeCoin = Instantiate (bronzeCoin, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;  
		}
		// If the dropChanceNumber is greater or equal to 49 and less than 60... 
		else if (dropChanceNumber >= 40 && dropChanceNumber < 60)  
		{
			silverCoin = Instantiate (silverCoin, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;  
		}
		// If the dropChanceNumber is greater or equal to 20 and less than 40... 
		else if (dropChanceNumber >= 20  && dropChanceNumber < 40) 
		{
			goldCoin = Instantiate (goldCoin, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;  
		}
	}


	/*
	public override void OnHit (Collider2D hitCollider)
	{
		if(MovementModel != null) 
		{
			Vector3 pushDirection = transform.position - hitCollider.gameObject.transform.position;
			pushDirection = pushDirection.normalized * HitPushStrength; 
			MovementModel.PushCharacter (pushDirection, HitPushDuration); 
		}
	}
	*/ 

}
