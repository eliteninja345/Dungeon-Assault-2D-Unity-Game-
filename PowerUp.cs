using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public int addDamage;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			other.GetComponent<Movement> ().PowerUpIncrease (addDamage);
			Destroy (gameObject);
		}
	}
}
