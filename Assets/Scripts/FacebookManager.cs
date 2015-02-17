using UnityEngine;
using System.Collections;

public class FacebookManager : MonoBehaviour {

	static FacebookManager instance = null;

	public string FullName;
	public string Gender;

	public static FacebookManager Instance() {
		return instance;
	}

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		FB.Init (onInitCallback, onHideUnityCallback);
		DontDestroyOnLoad (gameObject);
	}

	public void callInit() {
		FB.Init (onInitCallback, onHideUnityCallback);
	}

	public void callLogin() {
		/*
		 * public_profile gives us access to these fields
		 * id
		 * name
		 * first_name
		 * last_name
		 * link
		 * gender
		 * locale
		 * timezone
		 * updated_time
		 * verified
		 */
		FB.Login ("public_profile, email", onLoginCallback);
	}

	public void callLogout() {
		FB.Logout ();
	}

	private void onInitCallback() {
		if (FB.IsLoggedIn) {
			Application.LoadLevel ("user");
		}
	}

	private void onHideUnityCallback(bool isGameShown) {
		if (!isGameShown)
			Time.timeScale = 0; // pause game
		else
			Time.timeScale = 1; // resume game
	}

	private void onLoginCallback(FBResult result) {
		if (FB.IsLoggedIn) {
			Debug.Log ("FB Login Worked");

			// get profile picture
			FB.API (Util.GetPictureURL("me", 128, 128), Facebook.HttpMethod.GET, onPictureCallback);
			// get name
			FB.API ("/me?fields=id, first_name", Facebook.HttpMethod.GET, onNameCallback);

			Application.LoadLevel("user");
		}
		else
			Debug.Log ("FB Login Failed");
	}

	private void onPictureCallback(FBResult result) {

		if (result.Error != null) {
			Debug.Log ("Could not get profile picture");

			// set a default picture
		} 

		else {
			// FB returns a Texture2D handle it how you will
		}
	}

	private void onNameCallback(FBResult result) {
		if (result.Error != null) {
			Debug.Log ("Could not get a name");
			
		// set a default name
		} 

		else {
			FullName = result.Text.ToString();
		}
	}
}
