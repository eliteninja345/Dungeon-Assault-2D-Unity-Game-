// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public PlayerHealthManager playerHealth; 			// Reference to the Player's health game object 
	public GameObject enemy;							// Reference to the enemy game object  
	public float spawnTime; 							// Allows us to set the spawn time. 
	public Transform[] spawnPoints; 					// Allows us to set how many spawn points. 



	// Use this for initialization
	void Start () 
	{
		// InvokeRepeating ("Spawn", spawnTime, spawnTime); 		
	}

	void Spawn ()
	{
		if (playerHealth.playerCurrentHealth <= 0) 
		{
			return; 
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length); 

		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation); 
	}
		
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
		} 
	}
}
