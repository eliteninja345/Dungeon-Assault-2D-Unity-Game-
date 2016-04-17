using UnityEngine;
using System.Collections;

public class CollectTest : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "Player") 
		{
			Destroy (gameObject);
			Debug.Log ("die"); 
		}
	}
		
}
