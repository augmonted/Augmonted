using UnityEngine;
using System.Collections;

public class FBHolder : MonoBehaviour {

	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);
	}
	
	//-------------------------------------------------------------------------
	private void SetInit()
	{
		Debug.Log ("FB Init Done");

		// check if user is already logged in
		if (FB.IsLoggedIn)
		{
			// upon using app again
			Application.LoadLevel("user");
			Debug.Log ("FB Logged In");
		}
		else
		{
		}
	}

	//-------------------------------------------------------------------------
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
		FB.Login ("user_about_me, user_birthday", AuthCallback);
	}

	//-------------------------------------------------------------------------
	void AuthCallback(FBResult result)
	{
		if(FB.IsLoggedIn)
		{
			// upon signing in for first time
			Debug.Log ("FB Login Worked");
			Application.LoadLevel("user");
		}
		else
		{
			Debug.Log ("FB Login Failed");
		}
	}
}
