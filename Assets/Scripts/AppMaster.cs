using UnityEngine;
using System.Collections;

/*
 * Singleton object for each scene. Should be useful
 * for reusable methods we want.
 * e.g. the back button
 */

public class AppMaster : MonoBehaviour {

	public static AppMaster instance = null;

	// access this anywhere using AppMaster.AM.name
	public string name = "augmon";
	
	public static AppMaster Instance() {
		return instance;
	}

	void Awake() {
		Debug.Log("AppMaster: Awake");
		
		if (instance == null)
			instance = this;
		
		// keep the gameObject otherwise this
		// instance won't exist
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// if running on Android
		if (Application.platform == RuntimePlatform.Android)
		{
			// if back button is pressed
			if (Input.GetKeyDown(KeyCode.Escape)) { 
				// if AR scene go back to user scene
				if(Application.loadedLevelName == "main")
					Application.LoadLevel("user");
				// if user scene kill the app
				if(Application.loadedLevelName == "user")
					Application.Quit();
				// if login scene kill the app
				if(Application.loadedLevelName == "login")
					Application.Quit();
			}
		}
	}
}
