using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CallFBLogin() {
		FacebookManager.Instance ().callLogin ();
	}
}
