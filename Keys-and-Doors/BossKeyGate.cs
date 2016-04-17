using UnityEngine;
using System.Collections;

public class BossKeyGate : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "Player" && GameVariables.bossKeyCount>0) 
		{
			GameVariables.bossKeyCount--;
			Destroy (gameObject); 
		}
	}
}
