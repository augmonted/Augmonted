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
	Text subtitle;
	string name;

	// Use this for initialization
	void Start () {
		GameObject Cube = GameObject.Find ("Cube");
		
		GameObject playerAugmonModel = Instantiate(Resources.Load("Prefabs/" + FacebookManager.Instance ().playerAugmon, typeof(GameObject))) as GameObject;
		//playerAugmonModel.transform.parent = Cube.transform;
		
		GameObject spawnPoint = (GameObject)Instantiate (playerAugmonModel, playerAugmonModel.transform.position, playerAugmonModel.transform.rotation);
		playerAugmonModel.name = "PlayerAugmon";
		
		playerAugmonModel.renderer.enabled = true;
		
		profile = GameObject.Find("ProfileImage").GetComponent<Image>();
		header = GameObject.Find ("Header").GetComponent<Text>();
		subtitle = GameObject.Find ("Subtitle").GetComponent<Text>();
		//header.text = FacebookManager.Instance().FullName;
		if(header != null)
			Debug.Log("Found header");
	}
	
	// Update is called once per frame
	void Update () {
		profile.sprite = FacebookManager.Instance().ProfilePic;
		header.text = FacebookManager.Instance().FullName;
		subtitle.text = "Step Count: " + FeaturePedometer.Instance().stepCnt.ToString();
	}
}
