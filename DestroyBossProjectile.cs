// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class DestroyBossProjectile : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		// Both if statements that destroys the arrow after two seconds. 
		if (gameObject.name == "bossSlash(Clone)") 
		{
			Destroy (gameObject, 0.8f);
		} 

		if (gameObject.name == "bossSlash 1(Clone)") 
		{
			Destroy (gameObject, 2.5f);
		} 

	}
}
