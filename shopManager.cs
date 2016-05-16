// What if I told you I like Metal Gear...? 
// Put this script the item. 
using UnityEngine;
using System.Collections;

public class shopManager : MonoBehaviour 
{
	public GameObject item;						// The item that is being sold. 
	public int[] itemCost = {10, 15, 20};  		// The cost of the item. 
	public MoneyManager playerMoneyCount; 		// Reference to the MoneyManager class. 

	// Text variables 
	public TextAsset theText; 

	public int startLine;
	public int endLine; 

	public TextBoxManager theTextBox; 

	public bool destoryWhenActivated; 

	public bool requireButtonPress; 
	private bool waitForPress; 
	// 

	// Use this for initialization
	void Start () 
	{
		// Reference to the moneyManager.cs file.
		// playerMoneyCount = GetComponent<MoneyManager>(); 
		theTextBox = FindObjectOfType<TextBoxManager> (); 
	}
		
	void Update ()
	{
		if (waitForPress && Input.GetKeyDown (KeyCode.J))
		{
			theTextBox.ReloadScript (theText); 
			theTextBox.currentLine = startLine; 
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destoryWhenActivated) 
			{
				Destroy (gameObject); 
			} 
		}
	}
	/*
	void OnTriggerEnter2D (Collider2D shopitem)
	{
			 
		if (shopitem.gameObject.name == "Player") 
		{
			// textbox; 

			// If the player's money amount is more than the first item cost array. 
			if (playerMoneyCount.moneyAmount >= itemCost[0]) 
			{
				// Subtract from first item cost array. 
				playerMoneyCount.moneyAmount -= itemCost[0]; 
				playerMoneyCount.SetCountMoneyAmount (); 
				Destroy (gameObject); 
				Debug.Log ("I bought this item!"); 



			}

			// 
			else if (playerMoneyCount.moneyAmount <= itemCost[0]) 
			{
				Debug.Log ("You do not have enough money!"); 
			}
		}
	} // OnTriggerEnter2D
	*/ 

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			if (requireButtonPress) 
			{
				waitForPress = true; 
				return; 
			}
			theTextBox.ReloadScript (theText); 
			theTextBox.currentLine = startLine; 
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destoryWhenActivated) 
			{
				Destroy (gameObject); 
			} 
		} // If player
	} // OnTriggerEnter2D

	void OnTriggerExit2D (Collider2D other2)
	{
		if (other2.gameObject.name == "Player") 
		{
			waitForPress = false; 
		}
	}


} // Class 
