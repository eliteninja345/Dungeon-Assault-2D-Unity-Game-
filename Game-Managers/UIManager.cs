// What if I told you I like Metal Gear...?
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour 
{
	public Slider healthBar;					// Reference to the slider
	public Text HPText; 						// Reference to the text
	public PlayerHealthManager playerHealth; 	// Reference to the Player GameObject 
	
	// Update is called once per frame
	void Update () 
	{
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth; 
	}


}
