using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;

public class DAO : MonoBehaviour {
	string url = "http://ec2-54-183-168-17.us-west-1.compute.amazonaws.com/augmonted/user/login";
	NameValueCollection col = new NameValueCollection();
	
	// Use this for initialization
	void Start () {
		Debug.Log ("api start");
		string my_data = "{\"email\":\"aaa@aaa.com\",\"password\":\"aaa\"}";

		Hashtable headers = new Hashtable ();
		headers.Add ("Content-Type", "application/json");
		byte[] pData = Encoding.UTF8.GetBytes (my_data);
		WWW www = new WWW (url, pData, headers);
		// make new form
		//WWWForm form = new WWWForm ();
		
		//form.AddField ("email", "aaa@aaa.com");
		//form.AddField ("password", "aaa");
		
		// using this ctor the www is automatically a POST request
		//WWW www = new WWW (url, form);
		
		StartCoroutine (WaitForRequest (www));
		
		/*
        col ["email"] = "aaa@aaa.com";
        col ["password"] = "aaa";

        using (WebClient client = new WebClient()) {
            byte[] response = client.UploadValues(url, "POST", col);

            string result = System.Text.Encoding.UTF8.GetString(response);

            Debug.Log(result);
            client.Dispose();
        }
        */
	}
	
	IEnumerator WaitForRequest(WWW www) {
		yield return www;
		
		// check for errors
		if(www.error == null) {
			Debug.Log("WWW OK! - result: " + www.text);
		}
		else {
			Debug.Log("WWW Error: " + www.error);   
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
