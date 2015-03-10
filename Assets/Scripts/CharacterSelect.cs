using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	public static GameObject currentObject;
	public GameObject character1Glow;
	public GameObject character2Glow;
	public GameObject character3Glow;
	public GameObject character4Glow;
	
	// Use this for initialization
	void Start () {
		character1Glow.renderer.enabled = true;  // We're going to make sure all of the highlighted glows are OFF at scene start.
		character2Glow.renderer.enabled = false;
		character3Glow.renderer.enabled = false;
		character4Glow.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast (ray, out hit, 100))
			{
				// The pink text is where you would put the name of the object you want to click on (has attached collider).
				
				if(hit.collider.name == "_Character1") 
					SelectedCharacter1(); //Sends this click down to a function called "SelectedCharacter1(). Which is where all of our stuff happens.
				
				if(hit.collider.name == "_Character2")
					SelectedCharacter2();
				
				if(hit.collider.name == "_Character3")
					SelectedCharacter3();
				
				if(hit.collider.name == "_Character4")
					SelectedCharacter4();
			}                
		} 
	}
	
	void SelectedCharacter1() {
		Debug.Log ("Character 1 SELECTED"); //Print out in the Unity console which character was selected.
		character1Glow.renderer.enabled = true; //these lines turn on or off the appropriate character glow.
		character2Glow.renderer.enabled = false;
		character3Glow.renderer.enabled = false;
		character4Glow.renderer.enabled = false;
		
		FacebookManager.Instance().playerAugmon = "bird"; 
	}
	
	void SelectedCharacter2() {
		Debug.Log ("Character 2 SELECTED"); //Print out in the Unity console which character was selected.
		character1Glow.renderer.enabled = false; //these lines turn on or off the appropriate character glow.
		character2Glow.renderer.enabled = true;
		character3Glow.renderer.enabled = false;
		character4Glow.renderer.enabled = false; 
	
		FacebookManager.Instance().playerAugmon = "bunny";
	}
	
	void SelectedCharacter3() {
		Debug.Log ("Character 3 SELECTED"); //Print out in the Unity console which character was selected.
		character1Glow.renderer.enabled = false; //these lines turn on or off the appropriate character glow.
		character2Glow.renderer.enabled = false;
		character3Glow.renderer.enabled = true;
		character4Glow.renderer.enabled = false;
		
		FacebookManager.Instance().playerAugmon = "cat"; 
	}
	
	void SelectedCharacter4() {
		Debug.Log ("Character 4 SELECTED"); //Print out in the Unity console which character was selected.
		character1Glow.renderer.enabled = false; //these lines turn on or off the appropriate character glow.
		character2Glow.renderer.enabled = false;
		character3Glow.renderer.enabled = false;
		character4Glow.renderer.enabled = true;
		
		FacebookManager.Instance().playerAugmon = "dog"; 
	}
}