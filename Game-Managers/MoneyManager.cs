// What if I told you I like Metal Gear...?
// Put this script on the player 
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MoneyManager : MonoBehaviour
{
	public Text moneyCount; 		// Reference to the text money count. 
	public int moneyAmount; 		// Stores our money count when we collect them from monsters. 

	// Should these be private instead...? 
	[HideInInspector] public int bronzeAmount = 1; 
	[HideInInspector] public int silverAmount = 5; 
	[HideInInspector] public int goldAmount = 10; 

	// Use this for initialization
	void Start () 
	{
		// When the game starts, we start out with no money. 
		moneyAmount = 0; 
		SetCountMoneyAmount (); 
	}

	// Update is called once per frame
	void Update()
	{

	}

	// Add money upon touching the coin
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Bronze") 
		{		
			// Add +1 to moneyAmount.  
			moneyAmount += bronzeAmount; 
			SetCountMoneyAmount (); 
		}

		if (other.gameObject.tag == "Silver") 
		{
			// Add +5 to moneyAmount. 
			moneyAmount += silverAmount; 
			SetCountMoneyAmount (); 
		}

		if (other.gameObject.tag == "Gold") 
		{
			// Add +10 to moneyAmount.  
			moneyAmount += goldAmount; 
			SetCountMoneyAmount (); 
		}
	}

	// Set up to subtract money when we shop. 

	void SetCountMoneyAmount()
	{
		moneyCount.text = "Coins: " + moneyAmount.ToString (); 
	}



}
