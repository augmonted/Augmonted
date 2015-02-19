using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This class will get the user facebook profile image
 * and name and email from the Facebook login.
 */
public class UserProfile : MonoBehaviour {

	Image image;
	Sprite ProfilePic;
	string name;

	// Use this for initialization
	void Start () {
		//image = gameObject.GetComponentInChildren<Image>();
		image = GameObject.Find("ProfileImage").GetComponent<Image>();
		ProfilePic = FacebookManager.Instance().ProfilePic;
		image.sprite = FacebookManager.Instance().ProfilePic;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
