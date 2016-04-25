// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class bossProjectileFollow : MonoBehaviour 
{
	private Vector3 Player;
	private Vector2 Playerdirection;
	private float Xdif;
	private float Ydif;
	private float speed = 10f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Player = GameObject.Find ("Player").transform.position;

		Xdif = Player.x - transform.position.x;
		Ydif = Player.y - transform.position.y;

		Playerdirection = new Vector2 (Xdif, Ydif);

		GetComponent<Rigidbody2D>().AddForce(Playerdirection.normalized * speed);
	}
}
