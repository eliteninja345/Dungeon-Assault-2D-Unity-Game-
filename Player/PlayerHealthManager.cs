// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PlayerHealthManager : MonoBehaviour 
{
	public int playerMaxHealth;						// Max Health 
	public int playerCurrentHealth; 				// Current Health

	private bool flashActive;						// Is the player flashing when they get hit?
	public float flashLength; 						// The duration of the flash time. 
	private float flashCounter; 					// Number of times the flash is going on. 

	public Texture Loser;

	public float LX1;
	public float LX2;
	public float GuiX1;
	public float GuiX2;
	public float GuiY1;
	public float GuiY2;


	private SpriteRenderer playerSprite; 			// References the Player's sprite render.

	private Rigidbody2D playerRigidbody2D; 			// References the Player's rigidbody2D. 
	private bool kinematic; 						// Checks if the kinematic on the Rigidbody2D is on. 

	private BoxCollider2D playerBoxCollider2D; 
	private bool isColliderOn; 

	// Game over Text 
	public Text gameOverText; 
	private bool isGameOver = false; 

	// Win Text 
	public Text winText; 
	private bool isWin = false; 

	public AudioClip gameOverSound; 
	public AudioClip lowHealthSound; 
	public AudioClip levelMusic; 

	// Use this for initialization
	void Start () 
	{
		// At the start of our game, we want the current health to be the same as the max health. 
		playerCurrentHealth = playerMaxHealth; 
		playerSprite = GetComponent<SpriteRenderer> (); 
		playerRigidbody2D = GetComponent<Rigidbody2D> (); 
		playerBoxCollider2D = GetComponent<BoxCollider2D> (); 

		gameOverText.enabled = false; 
		winText.enabled = false; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerCurrentHealth <= 0 && !isGameOver) 
		{
			isGameOver = true; 
			Time.timeScale = 0;
			AudioManager.instance.PlaySingle (gameOverSound); 
			AudioManager.instance.musicSource.Stop (); 
			//gameOverText.enabled = true; 
			//gameObject.SetActive (false);
		}

		if (playerCurrentHealth > 0) 
		{
			Time.timeScale = 1;
			// AudioManager.instance.musicSource.Play (levelMusic); 
			//gameOverText.enabled = true; 
			//gameObject.SetActive (false);
		}

		// If the playerCurrentHealth is more than the playerMaxHealth...
		if (playerCurrentHealth > playerMaxHealth) 
		{
			// Then the playerCurrentHealth is the playerMaxHealth and cannot gain any more health potions unless they lose health. 
			playerCurrentHealth = playerMaxHealth; 
		}

		// Player flashing when they get hit. 
		if (flashActive) 
		{
			if (flashCounter > flashLength * .66f)
			{
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else if (flashCounter > flashLength * .33f) 
			{
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			}
			else if (flashCounter > flashLength * 0f) 
			{
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
				playerBoxCollider2D.enabled = false; 
			}
			else
			{
				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f); 
				flashActive = false; 
				playerBoxCollider2D.enabled = true;
			}
			flashCounter -= Time.deltaTime; 
		}
	}

	void OnGUI(){
		if(isGameOver){
			RenderSettings.fogDensity = 1;
			GUI.DrawTexture (new Rect (0, 0, Screen.width * LX1, Screen.height * LX2), Loser);




			if (GUI.Button (new Rect(Screen.width *  GuiX1, Screen.height * GuiY1, Screen.width * .5f, Screen.height * .1f), "Retry?" )){
				Application.LoadLevel ("Alpha2");

				isGameOver = false;
			}

			if (GUI.Button (new Rect(Screen.width * GuiX2, Screen.height * GuiY2, Screen.width * .5f, Screen.height * .1f), "Quit" )){
				Application.LoadLevel ("mainMenu");
			}
		}
	}
		
	// The 'int damageToGive is how much we want to damage the player. 
	public void HurtPlayer(int damageToGive)
	{
		// This is the same thing as saying 'playerCurrentHealth = playerCurrentHealth - damageToGive; 
		playerCurrentHealth -= damageToGive; 
		flashActive = true; 
		flashCounter = flashLength; 
	}

	// We can set how much we want to heal the player. 
	public void HealPlayer(int healthToGive)
	{
		playerCurrentHealth += healthToGive; 
	}

	// Makes it so we do not overheal.  
	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth; 
	}
}
