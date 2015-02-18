using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
	void Awake()
	{
		gameObject.AddComponent<FacebookManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CallFBLogin() {
		FacebookManager.Instance ().callLogin ();
	}
}
