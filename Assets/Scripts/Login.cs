using UnityEngine;
using System.Collections;

/*
 * This class handles logging in the user into the app.
 * If the user is already logged in via Facebook then
 * lead them to the app. Otherwise have the user
 * log in via Facebook.
 */
public class Login : MonoBehaviour {

	void Awake()
	{
		if (FacebookManager.Instance ().IsLogged ())
			Application.LoadLevel ("user");
	}
	
	// Update is called once per frame
	void Update () {
		if (FacebookManager.Instance ().IsLogged ())
			Application.LoadLevel ("user");
		else {
			// handle errors here
		}
	}

	public void CallFBLogin() {
		FacebookManager.Instance ().callLogin ();
	}
}
