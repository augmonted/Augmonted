using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;

/*
 * This class is the wrapper for the Facebook API.
 * The single instance is use to call the API methods.
 * To call FB APIs simply do FacebookManager.Instance().MethodName()
 * 
 * DO NOT use Application.LoadLevel in here. Leave that up to
 * scripts local to the scene.
 */
public class FacebookManager : MonoBehaviour {

	static FacebookManager instance = null;

	private string FullName;
	private string Gender;

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

	public bool IsLogged() {
		return FB.IsLoggedIn;
	}

	private void onInitCallback() {
		// do something if you want
		return;
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
		}
		else
			Debug.Log ("FB Login Failed");
	}

	private void onPictureCallback(FBResult result) {

		if (result.Error != null) {
			Debug.Log ("Could not get profile picture");
			return;
			// set a default picture
		} 

		else {
			return;// FB returns a Texture2D handle it how you will
		}
	}

	private void onNameCallback(FBResult result) {
		if (result.Error != null) {
			Debug.Log ("Could not get a name");
			return;
		// set a default name
		} 

		else {
			var dict = Json.Deserialize(result.Text) as Dictionary<string, object>;
			FullName = (string) dict["name"];
			return;
		}
	}
}
