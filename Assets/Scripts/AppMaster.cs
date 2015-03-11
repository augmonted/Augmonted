using UnityEngine;
using System.Collections;

/*
 * Singleton object for each scene. Should be useful
 * for reusable methods we want.
 * e.g. the back button
 */

public class AppMaster : MonoBehaviour {

	public static string currentScene = "splash";

	public static AppMaster instance = null;

	public GoogleAnalyticsV3 googleAnalytics;

	public static AppMaster Instance() {
		return instance;
	}

	void Awake() {
		Debug.Log("AppMaster: Awake");
		
		if (instance == null) {
						instance = this;
		}
		if (googleAnalytics != null) {
			googleAnalytics.LogScreen (currentScene);
		}

		// keep the gameObject otherwise this
		// instance won't exist
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (googleAnalytics);
	}

	// Use this for initialization
	void Start () {
		if (googleAnalytics != null) {
			googleAnalytics.LogScreen (currentScene);
		}
	}

	public void callHit() {
		Debug.Log ("Called Hit On: " + currentScene);
		if (googleAnalytics != null) {
			googleAnalytics.LogScreen (currentScene);
		}
	}
}
