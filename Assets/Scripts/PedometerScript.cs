using UnityEngine;
using System.Collections;

public class PedometerScript : MonoBehaviour {

	FeaturePedometer fp = null;

	// Use this for initialization
	void Start () {
		// This line works because the instance is initialized in the
		// Splash scene no need for if clause
		fp = FeaturePedometer.Instance ();
	}
	
	// Update is called once per frame
	void Update () {
		fp.UpdateStep ();
	}
}
