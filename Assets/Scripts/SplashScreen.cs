using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	
	// edit these values in unity editor
	public float timer;
	public string levelToLoad;
	public SceneFadeInOut SceneFader;

	// Use this for initialization
	void Start () {
		StartCoroutine ("DisplayScene");
	}

	IEnumerator DisplayScene() {
		yield return new WaitForSeconds (timer);
		AppMaster.currentScene = levelToLoad;
		AppMaster.Instance ().callHit ();
		Application.LoadLevel (levelToLoad);
	}

	// Update is called once per frame
	void Update () {
		if (timer - Time.time < 0.5f) {
			SceneFader.EndScene ();
		}
	}
}
