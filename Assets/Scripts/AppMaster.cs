using UnityEngine;
using System.Collections;

public class AppMaster : MonoBehaviour {

	public static AppMaster AM;

	// access this anywhere using AppMaster.AM.name
	public string name = "augmon";


	void Awake() {
		if (AM != null) {
			GameObject.Destroy (AM);
		} else {
			AM = this;
		}

		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
