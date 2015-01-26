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
			Debug.Log ("FB Logged In");
		}
		else
		{
			FBLogin();
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
	void FBLogin()
	{
		FB.Login ("user_about_me, user_birthday", AuthCallback);
	}

	//-------------------------------------------------------------------------
	void AuthCallback(FBResult result)
	{
		if(FB.IsLoggedIn)
		{
			Debug.Log ("FB Login Worked");
		}
		else
		{
			Debug.Log ("FB Login Failed");
		}
	}
}
