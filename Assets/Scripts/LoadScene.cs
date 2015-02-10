﻿using UnityEngine;
using System.Collections;
using System;

public class LoadScene : MonoBehaviour {
	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);
	}
	
	//-------------------------------------------------------------------------
	private void SetInit()
	{
		enabled = true; // magic global to wait on FB before rendering
		Debug.Log ("FB Init Done");
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

	public void loadScene(string scene) {
		if (scene.Equals ("login")) {
			FB.Logout();
			StartCoroutine ("Logout");
		}

		Application.LoadLevel (scene);
	}

	IEnumerator CheckForSuccessfulLogout() {
		// keep yielding until no longer logged in
		if(FB.IsLoggedIn) {
			Debug.Log("Logging out - still logged in" + DateTime.Now.ToString("h:mm:ss tt"));
			yield return new WaitForSeconds (0.1f);
			StartCoroutine("CheckForSuccessfulLogout");
		}
		else {
			// successful logout, do what you want here
			Debug.Log("Logged out!");
			Application.LoadLevel("login"); // logged out, go load the login level now
		}
	}

	IEnumerator Logout() {
		// set the indicator to use
		Handheld.SetActivityIndicatorStyle (AndroidActivityIndicatorStyle.Large);
		Handheld.StartActivityIndicator ();

		Debug.Log ("Logout was pressed");
		// keep spinning until coroutine finishes
		yield return StartCoroutine ("CheckForSuccessfulLogout");
	}
}