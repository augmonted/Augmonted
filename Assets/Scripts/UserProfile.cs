using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This class will get the user facebook profile image
 * and name and email from the Facebook login.
 */
public class UserProfile : MonoBehaviour {

	Image image;
	string name;

	// Use this for initialization
	void Start () {
		image = GameObject.Find("ProfileImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		image.sprite = FacebookManager.Instance().ProfilePic;
	}
}
