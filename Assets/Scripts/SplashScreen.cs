﻿using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	public float timer = 3f;
	public string levelToLoad = "main";

	// Use this for initialization
	void Start () {
		StartCoroutine ("DisplayScene");
	}

	IEnumerator DisplayScene() {
				yield return new WaitForSeconds (timer);
				Application.LoadLevel (levelToLoad);
		}

	// Update is called once per frame
	void Update () {
	
	}
}