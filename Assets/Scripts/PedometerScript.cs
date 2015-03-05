using UnityEngine;
using System.Collections;

public class PedometerScript : MonoBehaviour {

	FeaturePedometer fp = null;

	// Use this for initialization
	void Start () {
		fp = FeaturePedometer.Instance();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("PedometerScript in scene: " + Application.loadedLevelName);
		fp.UpdateStep();
	}
}
