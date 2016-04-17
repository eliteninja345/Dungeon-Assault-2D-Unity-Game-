using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {


	private bool isPaused;
	private GUISkin guiSkin;

	public float guiPlacementY;
	public float guiPlacementY2;
	public float guiPlacementY3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		/*// Freezes gamestate If escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused) { 
			// Time.timeScale sets the speed of the game. 
			Time.timeScale = 0; 
			isPaused = true;
		} 
		// Unfreeze gamestate If escape is pressed
		else if (Input.GetKeyDown (KeyCode.Escape) && isPaused) { 
			// Time.timeScale sets the speed of the game. 
			Time.timeScale = 1; 
			isPaused = false;
		}*/
	}



	///////////////////////////////////////
	//////////// Pause Menu ///////////////
	///////////////////////////////////////

	void OnGUI()
	{
		GUI.skin = guiSkin;

		if (isPaused) {
			RenderSettings.fogDensity = 1;
			//Buttons
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * guiPlacementY, Screen.width * .5f, Screen.height * .1f), "Continue")) {
				Time.timeScale = 1; 
				isPaused = false;
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Restart from the beginning")) {
				Application.LoadLevel ("Alpha2");
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * guiPlacementY3, Screen.width * .5f, Screen.height * .1f), "Quit")) {
				Application.Quit ();
			}
		}

	}
}
