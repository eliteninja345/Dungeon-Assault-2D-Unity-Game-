// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 				// Allows us to access the UI.

public class FloatingNumbers : MonoBehaviour {

	public float moveSpeed;			// The speed that the number shows up at. 
	public int damageNumber;		// Shows the number of the damage that we are dealing.
	public Text displayNumber; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Since displayNumber is a string... (12:20) 
		displayNumber.text = "" + damageNumber;
		transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);  
	}
}
