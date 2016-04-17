using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour 
{
	public float guiPlacementY;
	public float guiPlacementY2;
	public float guiPlacementY3;


	private bool isGameOver = false; 	// Flag to see if game is over. 
	private bool isPaused = false;
	private GUISkin guiSkin;


	//Movement Variables
	int direction;

	float shootUp = 1;
	float shootRight = 2;
	float shootLeft = 3;
	float shootDown = 4;
	Rigidbody2D bPrefabUp;
	Rigidbody2D bPrefabDown;
	Rigidbody2D bPrefabLeft;
	Rigidbody2D bPrefabRight;
	public Rigidbody2D arrowBottom;
	public Rigidbody2D arrowTop;
	float attackSpeed = 0.5f;			// original was 0.5f 
	float coolDown;
	float arrowSpeed = 420f;			// original was 420f 
	private float movex; 
	private float movey;
	public float moveSpeed;
	Animator anim;

	//Damage Increase
	public int startDamage;
	public int currentDamage;
	public int maxDamage;

	[SerializeField]
	private GameObject arrowPrefab;

	public AudioClip arrowFire1;
	public AudioClip arrowFire2; 
	// public AudioClip levelMusic; 

	void Start ()
	{
		// Sets starting Damage 
		currentDamage = startDamage;
	}

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}


	void FixedUpdate () {
		// Changed Input.GetAxis to Input.GetAxisRaw. 
		movex = Input.GetAxisRaw ("Horizontal");
		movey = Input.GetAxisRaw ("Vertical");

		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * moveSpeed, movey * moveSpeed);
	}
		
	void Update()
	{
		// If it's not game over, we can move. 
		if (!isGameOver) 
		{
			moveUp ();
			moveLeft ();
			moveRight ();
			moveDown ();
		}

		if (Time.time >= coolDown) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				Fire ();
				AudioManager.instance.RandomizeSfx (arrowFire1, arrowFire2); 
			}
		}


		// Makes it so damage cannot be maxed over the intended amount. 
		if (currentDamage > maxDamage) 
		{
			currentDamage = maxDamage; 
		}

		// Freezes gamestate If escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused) 
		{ 
			// Time.timeScale sets the speed of the game. 
			Time.timeScale = 0;
			isPaused = true;
			Debug.Log ("Pause");
		} 

		// Unfreeze gamestate If escape is pressed
		else if (Input.GetKeyDown (KeyCode.Escape) && isPaused) 
		{ 
			// Time.timeScale sets the speed of the game. 
			Time.timeScale = 1;
			isPaused = false;
			Debug.Log ("Unpause");
		}

	}



	///////////////////////////////////////
	//////////// Pause Menu ///////////////
	///////////////////////////////////////

	void OnGUI()
	{
		GUI.skin = guiSkin;

		if (isPaused) 
		{
			
			RenderSettings.fogDensity = 1;
			//Buttons
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * guiPlacementY, Screen.width * .5f, Screen.height * .1f), "Continue")) 
			{
				Time.timeScale = 1; 
				isPaused = false; 
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Restart from the beginning")) 
			{
				Application.LoadLevel ("Alpha2");
				// AudioManager.instance.musicSource (levelMusic); 
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * guiPlacementY3, Screen.width * .5f, Screen.height * .1f), "Quit")) 
			{
				Application.LoadLevel ("mainMenu");
			}

			Time.timeScale = 0; 
		}
			
	}

	void Fire(){

		/*
		 bPrefab = Instantiate (arrow, new Vector3
            (transform.position.x, transform.position.y,
                transform.position.z), transform.rotation) as Rigidbody2D;*/
		
		//The 'Physics2D.IgnoreCollision ...' allows the arrow to ignore collision with the character collider. 

		if (direction == shootUp) {
			bPrefabUp = Instantiate (arrowBottom, transform.position, Quaternion.Euler (new Vector3 (0, 0, 90))) as Rigidbody2D;
			Physics2D.IgnoreCollision (bPrefabUp.GetComponent<Collider2D>(), transform.root.GetComponent<Collider2D>());
			// AudioManager.instance.RandomizeSfx (arrowFire1, arrowFire2); 
		}

		if (direction == shootRight) {
			bPrefabRight = Instantiate (arrowTop, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			Physics2D.IgnoreCollision (bPrefabRight.GetComponent<Collider2D>(), transform.root.GetComponent<Collider2D>()); 
			// AudioManager.instance.RandomizeSfx (arrowFire1, arrowFire2); 
		}

		if (direction == shootLeft) {
			bPrefabLeft = Instantiate (arrowBottom, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180))) as Rigidbody2D;
			Physics2D.IgnoreCollision (bPrefabLeft.GetComponent<Collider2D>(), transform.root.GetComponent<Collider2D>());  
			// AudioManager.instance.RandomizeSfx (arrowFire1, arrowFire2); 
		}

		if (direction == shootDown) {
			bPrefabDown = Instantiate (arrowTop, transform.position, Quaternion.Euler (new Vector3 (0, 0, 270))) as Rigidbody2D;
			Physics2D.IgnoreCollision (bPrefabDown.GetComponent<Collider2D>(), transform.root.GetComponent<Collider2D>());   
			// AudioManager.instance.RandomizeSfx (arrowFire1, arrowFire2); 
		}
		shootDirection ();

	}

	void moveUp()
	{
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) 
		{
			anim.SetBool ("Up", true);
			anim.SetBool ("Left", false);
			anim.SetBool ("Down", false);
			anim.SetBool ("Right", false);
			direction = 1;
		}
		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Up", false);
			direction = 1;
		}
	}

	void moveRight()
	{
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
		{
			anim.SetBool("Up", false);
			anim.SetBool("Left", false);
			anim.SetBool("Down", false);
			anim.SetBool("Right", true);
			direction = 2;
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
		{
			anim.SetBool("Right", false);
			direction = 2;
		}

	}
	void moveLeft()
	{
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			anim.SetBool("Up", false);
			anim.SetBool("Left", true);
			anim.SetBool("Down", false);
			anim.SetBool("Right", false);
			direction = 3;
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) )
		{
			anim.SetBool("Left", false);
			direction = 3;
		}
	}

	void moveDown()
	{
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			anim.SetBool("Up", false);
			anim.SetBool("Left", false);
			anim.SetBool("Down", true);
			anim.SetBool("Right", false);
			direction = 4;
		}
		if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
		{
			anim.SetBool("Down", false);
			direction = 4;
		}
	}

	void shootDirection()
	{
		if (direction == shootUp) 
		{
			bPrefabUp.GetComponent<Rigidbody2D>().AddForce (transform.up * arrowSpeed);
		}
		if (direction == shootRight) 
		{
			bPrefabRight.GetComponent<Rigidbody2D>().AddForce (transform.right * arrowSpeed);  
		}
		if (direction == shootLeft) 
		{
			bPrefabLeft.GetComponent<Rigidbody2D>().AddForce (transform.right * -arrowSpeed);  
		}
		if (direction == shootDown) 
		{
			bPrefabDown.GetComponent<Rigidbody2D>().AddForce (transform.up * -arrowSpeed); 
		}
	}

	// public float knockback = 0.5f; 

	// Us picking up the Power Up. 
	public void OnTriggerEnter2D(Collider2D other)
	{
		// Checks if the tag is listed as 'PowerUp'. 
		if (other.gameObject.tag == "Projectile") 
		{
			// Accesses the attackTrigger.cs script.
			other.gameObject.GetComponent<attackTrigger> ().damageAmount (currentDamage); 
		}
	}

	public void PowerUpIncrease(int addDamage){
		//Adds additional damage to the current damage...
		currentDamage += addDamage;
	}

}