using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBHolder : MonoBehaviour {
	
	public GameObject UIFBIsLoggedIn;
	public GameObject UIFBIsNotLoggedIn;
	public GameObject UIFBAvatar;
	public GameObject UIFBUsername;
	
	// Initialization
	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);

		// preserve these GameObjects across scene changes
		DontDestroyOnLoad (UIFBAvatar);
		DontDestroyOnLoad (UIFBIsLoggedIn);
		DontDestroyOnLoad (UIFBUsername);
	}
	
	//-------------------------------------------------------------------------
	// Callback when initialization is complete
	private void SetInit()
	{
		Debug.Log ("FB Init Done");
		
		// check if user is already logged in
		if (FB.IsLoggedIn)
		{
			DealWithFBMenus (true);
			Debug.Log ("FB Logged In");
		}
		else
		{
			DealWithFBMenus (false);
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
			DealWithFBMenus (true);
			Debug.Log ("FB Login Worked");
		}
		else
		{
			DealWithFBMenus (false);
			Debug.Log ("FB Login Failed");
		}
	}
	
	//-------------------------------------------------------------------------
	void DealWithFBMenus(bool isLoggedIn)
	{
		if(isLoggedIn)
		{
			UIFBIsLoggedIn.SetActive (true);
			UIFBIsNotLoggedIn.SetActive (false);
			
			// Get profile picture
			FB.API (Util.GetPictureURL("me", 128, 128), Facebook.HttpMethod.GET, DealWithProfilePicture);
			// Get username

			// change scene
			Application.LoadLevel("user");
		}
		else
		{
			UIFBIsLoggedIn.SetActive (false);
			UIFBIsNotLoggedIn.SetActive (true);
		}
	}
	
	//-------------------------------------------------------------------------
	void DealWithProfilePicture(FBResult result)
	{
		// Check for errors when getting profile picture
		if(result.Error != null)
		{
			Debug.Log("Problem with getting profile picture");
			
			// Try to get the picture again
			FB.API (Util.GetPictureURL("me", 128, 128), Facebook.HttpMethod.GET, DealWithProfilePicture);
			return;
		}
		else
		{
			Debug.Log ("Got profile picture");
			UnityEngine.UI.Image userAvatar = UIFBAvatar.GetComponent<UnityEngine.UI.Image> ();
			userAvatar.sprite = Sprite.Create (result.Texture, new Rect(0, 0, 128, 128), new Vector2(0, 0));
		}
	}
}
