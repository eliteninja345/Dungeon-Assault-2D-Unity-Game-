// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class BossInput : MonoBehaviour 
{

	private BossStates bossSwitchState; 

	// Use this for initialization
	void Start () 
	{
		// Calling out the BossStates.cs file. 
		// By using GetComponentInParent, we can create game objects that are the child of the main game object and have that script work even though it is not on the 
		// same game object. 
		bossSwitchState = GetComponentInParent<BossStates>(); 
	
	}

	// Update is called once per frame
	// We will use this to switch between states. 
	void Update () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			bossSwitchState.states = BossStates.ENEMY_STATE.ATTACK; 
		} 

	}
}
