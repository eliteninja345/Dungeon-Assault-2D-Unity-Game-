// What if I told you I like Metal Gear...?
// Destory the money/coin upon collecting. 
using UnityEngine;
using System.Collections;

public class MoneySet : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Destroy (gameObject); 
		}
	}
}
