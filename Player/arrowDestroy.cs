using UnityEngine;
using System.Collections;

public class arrowDestroy : MonoBehaviour {

	public GameObject arrowBottom; 
	public GameObject arrowTop; 

	// Update is called once per frame
	void Update () 
	{
		// Both if statements that destroys the arrow after two seconds. 
		if (gameObject.name == "arrowTop(Clone)") 
		{
			Destroy (gameObject, 2);
		} 

		if (gameObject.name == "arrowBottom(Clone)") 
		{
			Destroy (gameObject, 2);
		}
	}
}
