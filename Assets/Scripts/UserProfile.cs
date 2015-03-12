using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This class will get the user facebook profile image
 * and name and email from the Facebook login.
 */
public class UserProfile : MonoBehaviour {

	public HealthBar HealthBarScript;
	Image profile;
	Text header;
	Text subtitle;
	string name;
	string augmonSelected;
	GameObject augmonModel;
	GameObject bird;
	GameObject bunny;
	GameObject cat;
	GameObject dog;

	// Use this for initialization
	void Start () {
		
		//GameObject playerAugmonModel = Instantiate(Resources.Load("Prefabs/" + FacebookManager.Instance ().playerAugmon, typeof(GameObject))) as GameObject;
		
		//GameObject spawnPoint = (GameObject)Instantiate (playerAugmonModel, playerAugmonModel.transform.position, playerAugmonModel.transform.rotation);
		//playerAugmonModel.name = "PlayerAugmon";
		
		//playerAugmonModel.renderer.enabled = true;
		
		//augmonMesh = Instantiate(Resources.Load("Prefabs/" + FacebookManager.Instance().playerAugmon, typeof(Material))) as Material;
		
		profile = GameObject.Find("ProfileImage").GetComponent<Image>();
		header = GameObject.Find ("Header").GetComponent<Text>();
		subtitle = GameObject.Find ("Subtitle").GetComponent<Text>();
		augmonSelected = FacebookManager.Instance().playerAugmon;
		augmonModel = GameObject.Find ("AugmonModel");
		//augmonModel = Instantiate(Resources.Load("Prefabs/" + FacebookManager.Instance().playerAugmon, typeof(GameObject))) as GameObject;
		augmonModel.SetActive(false);
		bird = GameObject.Find ("bird");
		bunny = GameObject.Find ("bunny");
		cat = GameObject.Find ("cat");
		dog = GameObject.Find ("dog");
		
		if(augmonSelected == "bird") {
			bird.SetActive(true);
			bunny.SetActive(false);
			cat.SetActive(false);
			dog.SetActive(false);
		}
		else if(augmonSelected == "bunny") {
			bird.SetActive(false);
			bunny.SetActive(true);
			cat.SetActive(false);
			dog.SetActive(false);
		}
		else if(augmonSelected == "cat") {
			bird.SetActive(false);
			bunny.SetActive(false);
			cat.SetActive(true);
			dog.SetActive(false);
		}
		else if(augmonSelected == "dog") {
			bird.SetActive(false);
			bunny.SetActive(false);
			cat.SetActive(false);
			dog.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		profile.sprite = FacebookManager.Instance().ProfilePic;
		header.text = FacebookManager.Instance().FullName;
		subtitle.text = "Step Count: " + ((int)HealthBarScript.pedometersteps + FeaturePedometer.Instance ().stepCnt);
	}
}
