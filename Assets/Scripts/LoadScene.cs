using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public void loadScene(string scene) {
		Application.LoadLevel (scene);
	}
	
}
