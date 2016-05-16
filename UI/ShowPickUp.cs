// What if I told you I like Metal Gear...?
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class ShowPickUp : MonoBehaviour 
{
	public Text countText;				// Reference to the countText gameObject 

	// Use this for initialization
	void Start () 
	{
		// When we start the game, our key count should be zero. 
		GameVariables.keyCountUI = 0; 
		SetCountText (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		// If our keyCount listed on the UI is 0, 
		if (GameVariables.keyCountUI == 0) 
		{
			// Then assign the keyCount for the UI to 0
			GameVariables.keyCountUI = 0; 
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the game object name is equal to "Player", 
		if (collider.gameObject.CompareTag ("Key")) 
		{
			// Add one to the keyCount for the UI. 
			GameVariables.keyCountUI += 1;  
			// Print out the string. 
			SetCountText (); 
			// Debug.Log ("Collected~!"); 
		}
			
		// If we have more than 0 keys in our keyCountUI and the locked door is tagged as 'Locked Door', 
		if (GameVariables.keyCountUI > 0 && collider.gameObject.CompareTag("Respawn")) 
		{
			// Subtract the keyCount for the UI by 1. 
			GameVariables.keyCountUI -= 1;
			// Print out the string. 
			SetCountText (); 
		}
	}
		
	void SetCountText()
	{
		countText.text = "Key Count: " + GameVariables.keyCountUI.ToString(); 

	}




}
