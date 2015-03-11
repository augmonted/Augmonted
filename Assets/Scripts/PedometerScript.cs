﻿using UnityEngine;
using System.Collections;

public class PedometerScript : MonoBehaviour {

	FeaturePedometer fp = null;

	// Use this for initialization
	void Start () {
		if (fp != null) {
			fp = FeaturePedometer.Instance ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fp != null) {
			fp.UpdateStep ();
		}
	}
}
