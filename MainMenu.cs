//Attached to Main Camara
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture background;

	public float guiPlacementY1;
	public float guiPlacementY2;


	void OnGUI(){
		//Background Display
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),background);

		//Buttons
		if (GUI.Button (new Rect(Screen.width *  .25f, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "Play Game" )){
			Application.LoadLevel ("Alpha2");
		}
		if (GUI.Button (new Rect(Screen.width *  .25f, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Quit" )){
			Application.Quit ();
		}
	}
	
	
}
