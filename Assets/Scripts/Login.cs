using UnityEngine;
using System.Collections;

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
	}

	public void CallFBLogin() {
		FacebookManager.Instance ().callLogin ();
	}
}
