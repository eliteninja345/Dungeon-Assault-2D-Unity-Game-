using UnityEngine;
using System.Collections;

public class BossStates : MonoBehaviour {

	public ENEMY_STATE states;			// Allow us to call out the enum. 
	public Vector3 pointB;				// We can set where point B is in the inspector.
	public Vector3 pointC; 				
	Rigidbody2D shot; 					
	public Rigidbody2D shotFire; 		// The Rigidbody of the game object. 
	public Rigidbody2D shotFireFollow; 	 
	float shotSpeed = 300f; 			// The speed of the projectile
	float shotSpeedFollow = 200f; 		

	private bossHealth bossHealth; 

	public void Awake()
	{
		// Start in the idle state. 
		states = ENEMY_STATE.IDLE; 
	}

	public void Start()
	{
		StartCoroutine (EnemyFSM ()); 
	}

	void Update()
	{
		switch (states) 
		{
		case ENEMY_STATE.IDLE:
			break; 
		case ENEMY_STATE.ATTACK:
			break; 	
		case ENEMY_STATE.ATTACK_2:
			break; 	
		}
	}

	IEnumerator EnemyFSM()
	{
		while (true) 
		{
			// This will not run unless the string has the name of the coroutine we want to start. 
			// It could be states.IDLE, states.ATTACK, etc. 
			yield return StartCoroutine (states.ToString ());	
		}
	}

	/* 
	---------------------------
		「Boss Idle State」
	---------------------------
	*/
	IEnumerator IDLE()
	{
		// Enter the idle state. 
		// Debug.Log ("Alright, seems no evil player is around, I can chill!"); 

		// Execute the idle state
		// This will loop as long this is still in the idle state. 
		while (states == ENEMY_STATE.IDLE) 
		{
			yield return new WaitForSeconds (1.0f); 
			// Debug.Log ("Sitting here...");
		}

		yield return new WaitForSeconds (1.0f); 
		// Exit the idle state. 
		// Debug.Log ("Uh, I guess I smell a player!"); 
	}

	/* 
	---------------------------
		「Boss Attack State」
	---------------------------
	*/
	IEnumerator ATTACK()
	{
		Vector3 pointA = transform.position;			// Point A comes from the boss' current position. 
		while (states == ENEMY_STATE.ATTACK) 
		{
			yield return StartCoroutine (MoveObject (transform, pointA, pointB, 1f));  
			bossFireFollow (); 
			bossFireSideLeft (); 
			bossFireSideRight (); 
			yield return StartCoroutine (MoveObject (transform, pointB, pointC, 1f)); 
			bossFire (); 
			bossFireSideLeft (); 
			yield return StartCoroutine (MoveObject (transform, pointC, pointB, 1f)); 
			bossFire (); 
			bossFireSideLeft (); 
			bossFireSideRight (); 
			yield return StartCoroutine (MoveObject (transform, pointB, pointA, 1f)); 
			bossFire ();
			bossFireSideRight (); 
		}

		// Exit the attack state
		// Debug.Log ("You're no longer dead meat I guess...?"); 
	}



	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		float i = 0.0f; 
		float rate = 1.0f / time; 
		while (i < 1.0f) 
		{
			i += Time.deltaTime * rate; 
			thisTransform.position = Vector3.Lerp (startPos, endPos, i);
			yield return null; 
		}
	}
		
	public enum ENEMY_STATE 
	{
		IDLE = 0,
		ATTACK = 1, 
		ATTACK_2 = 2
	}
			


	void bossFire() 
	{
		// Spawns the shotFire which is the bossSlash projectile. 
		shot = Instantiate (shotFire, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
		shot.GetComponent<Rigidbody2D>().AddForce (transform.up * -shotSpeedFollow); 
		// Physics2D.IgnoreCollision (shot.GetComponent<BoxCollider2D>(), transform.root.GetComponent<BoxCollider2D>());
	}

	void bossFireSideLeft() 
	{
		shot = Instantiate (shotFire, transform.position, Quaternion.Euler (new Vector3 (0, 0, 270))) as Rigidbody2D;
		shot.GetComponent<Rigidbody2D>().AddForce (transform.right * -shotSpeed); 
		// Physics2D.IgnoreCollision (shot.GetComponent<BoxCollider2D>(), transform.root.GetComponent<BoxCollider2D>());
	}
		
	void bossFireSideRight() 
	{
		shot = Instantiate (shotFire, transform.position, Quaternion.Euler (new Vector3 (0, 0, 90))) as Rigidbody2D;
		shot.GetComponent<Rigidbody2D>().AddForce (transform.right * shotSpeed); 
		// Physics2D.IgnoreCollision (shot.GetComponent<BoxCollider2D>(), transform.root.GetComponent<BoxCollider2D>());
	}

	// Physics2D.IgnoreCollision (shot.GetComponentInChildren<BoxCollider2D>(), transform.root.GetComponentInChildren<BoxCollider2D>());

	void bossFireFollow() 
	{
		// Spawns the shotFire which is the bossSlash projectile. 
		shot = Instantiate (shotFireFollow, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
		shot.GetComponent<Rigidbody2D>().AddForce (transform.up * -shotSpeedFollow); 
		// Physics2D.IgnoreCollision (shot.GetComponent<BoxCollider2D>(), transform.root.GetComponent<BoxCollider2D>());
	}

}
