using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This class will get the user facebook profile image
 * and name and email from the Facebook login.
 */
public class UserProfile : MonoBehaviour {

	Image profile;
	Text header;
	string name;

	// Use this for initialization
	void Start () {
		profile = GameObject.Find("ProfileImage").GetComponent<Image>();
		header = GameObject.Find ("Header").GetComponent<Text>();
		//header.text = FacebookManager.Instance().FullName;
		if(header != null)
			Debug.Log("Found header");
	}
	
	// Update is called once per frame
	void Update () {
		profile.sprite = FacebookManager.Instance().ProfilePic;
		header.text = FacebookManager.Instance().FullName;
	}
}
