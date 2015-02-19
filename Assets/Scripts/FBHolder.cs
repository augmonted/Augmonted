using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBHolder : MonoBehaviour {
	
	// Initialization
	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);
	}
	
	//-------------------------------------------------------------------------
	// Callback when initialization is complete
	private void SetInit()
	{
		enabled = true; // magic global to wait on FB before rendering
		Debug.Log ("FB Init Done");
		
		// check if user is already logged in
		if (FB.IsLoggedIn)
		{
			Debug.Log ("FB already Logged In");
			Application.LoadLevel("user");
		}
		else
		{
		}
	}
	
	//-------------------------------------------------------------------------
	// Callback when game is hidden
	private void OnHideUnity(bool isGameShown)
	{
		if(!isGameShown)
		{
			Time.timeScale = 0; // pause game
		}
		else
		{
			Time.timeScale = 1; // resume
		}
	}
	
	//-------------------------------------------------------------------------
	public void FBLogin()
	{
		FB.Login ("email", AuthCallback);
	}
	
	//-------------------------------------------------------------------------
	void AuthCallback(FBResult result)
	{
		if(FB.IsLoggedIn)
		{
			Debug.Log ("FB Login Worked on callback");
			Application.LoadLevel("user");
		}
		else
		{
			Debug.Log ("FB Login Failed");
		}
	}
}
