// What if I told you I like Metal Gear...? 
using UnityEngine;
using System.Collections;

public class restarLevel : MonoBehaviour {

	void Update()
	{
		if (Input.GetButtonDown ("p")) 
		{
			// When we restart the game, load the game level and the key counts. 
			Application.LoadLevel ("Alpha2");
			GameVariables.keyCount = 0; 
			GameVariables.bossKeyCount = 0; 
			// Time.timeScale = savedTimeScale; 
			// Time.timeScale sets the speed of the game. 
			// Time.timeScale = 1; 
			// Do not forget to reset the game variables here since they are static and need to be resetted manually. 
		}
	}

}
