// What if I told you I like Metal Gear...?
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour 
{
	public Slider healthBarSlider;			// Reference for slider
	public Text gameOverText; 				// Reference for text
	private bool isGameOver = false; 		// Flag to see if game is over

	Rigidbody2D rbody; 
	Animator anim; 

	// Use this for initialization
	void Start () 
	{
	
		// Gives us access to the components added to our player game object. 
		rbody = GetComponent<Rigidbody2D> (); 
		anim = GetComponent<Animator> (); 
		// gameOverText.enabled = false; 		// Disable GameOver text on start. 
	}
	
	// Update is called once per frame
	void Update () 
	{

		/*
		---------------
		Player Movement 
		--------------- 
		 */ 

		// Allows us to hit the 'AWSD' and arrow' 
		// GetAxisRaw returns us true or false. Animates towards the number.  
		// GetAxis only checks if it's on or off.  
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")); 

		// Are we moving...? 
		// If our vector isn't zero, then we have to be walking. 
		if (movement_vector != Vector2.zero) 
		{
			// If we are walking... 
			anim.SetBool ("iswalking", true);
			// We will transition from the idle state to the walking state. 
			// We set these float values within our walking clause because when we release the key, we still want to be facing the
			// direction we left it as. 
			anim.SetFloat ("input_x", movement_vector.x); 
			anim.SetFloat ("input_y", movement_vector.y);
		} 
		else 
		{
			// If we are not walking, then we do not transition into the walking state. 
			anim.SetBool ("iswalking", false); 
		}

		// where we are + movement_vector (anim.SetFloat) * Instead of moving meters per frame, we are moving meters per second. 
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);  
	}

	// Checks if player enters/stays on the enemy hitbox
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.name=="Enemy" && healthBarSlider.value>0) 
		{
			healthBarSlider.value -= .011f; // Reduce health
		} 
		else 
		{
			isGameOver = true;					// Set game over to true
			gameOverText.enabled = true; 		// Enable GameOver Text
		}
	}
}
