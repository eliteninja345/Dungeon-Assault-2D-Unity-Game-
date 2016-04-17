// What if I told you I like Metal Gear...?
using UnityEngine;
using System.Collections;

public class EnemyFollowAI : MonoBehaviour {
     
	private Vector3 Player;
	private Vector2 Playerdirection;
	private float Xdif;
	private float Ydif;
	private float speed;

	void Start () {
		speed = 2f; 
	}

	// Update is called once per frame
	void Update () {
		// Cannot implicitly convert type `UnityEngine.Transform' to `UnityEngine.Vector3'
		Player = GameObject.Find ("Player").transform.position;

		Xdif = Player.x - transform.position.x;
		Ydif = Player.y - transform.position.y;

		Playerdirection = new Vector2 (Xdif, Ydif);

		GetComponent<Rigidbody2D>().AddForce(Playerdirection.normalized * speed);

		// OLD CODE
		// rigidbody2D.AddForce (Playerdirection.normalized * speed);
	}
}

