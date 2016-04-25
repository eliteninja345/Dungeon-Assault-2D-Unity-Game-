// What if I told you I like Metal Gear...?
// Put this script onto the boss. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class bossHealth : MonoBehaviour 
{
	public int MaxHealth; 
	public int CurrentHealth; 

	public Text winText; 
	private bool isWin = false; 

	public GameObject prize; 

	public AudioClip gameWinSound; 

	void Start ()
	{
		// At the start of our game, we want the current health of the enemy to equal the max health.
		CurrentHealth = MaxHealth; 
	}


	void Update ()
		{


		// If the enemy's current health is less than zero...
			if (CurrentHealth <= 0 && !isWin) 
			{
				isWin = true; 
				Time.timeScale = 0;
				//gameOverText.enabled = true; 
				//gameObject.SetActive (false);

			}

			if(isWin == true)
			{
				Application.LoadLevel ("WinScreen");
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

}

