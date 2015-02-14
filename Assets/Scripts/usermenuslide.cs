using UnityEngine;
using System.Collections;

public class usermenuslide : MonoBehaviour {
	//refrence for the pause menu panel in the hierarchy
	public GameObject ButtonPanel;
	//animator reference
	private Animator anim;
	//variable for checking if the game is paused 
	private bool isClicked = false;

	public void usermenuOnClick(){
		isClicked = !isClicked;
		//pause the game on escape key press and when the game is not already paused
		if(!isClicked){
			moveMenu();
		}
		//unpause the game if its paused and the escape key is pressed
		else if(isClicked){
			removeMenu();
		}
	}

	// Use this for initialization
	void Start () {
		//unpause the game on start
		Time.timeScale = 1;
		//get the animator component
		anim = ButtonPanel.GetComponent<Animator>();
		//disable it on start to stop it from playing the default animation
		anim.enabled = enabled;
		anim.Play ("usermenuslide");
	}


	//function to pause the game
	public void moveMenu(){
		//play the Slidein animation
		anim.Play("usermenuslide");
		Time.timeScale = 0;
	}
	//function to unpause the game
	public void removeMenu(){
		//play the SlideOut animation
		anim.Play("usermenuslideout");
		Time.timeScale = 1;
	}
	
}