using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideCustomize : MonoBehaviour {

	CustomizeView CV;

	// Use this for initialization
	void Start () {
		CV=transform.parent.parent.GetComponent<CustomizeView>();
	}

	void TappedImage () {
		Debug.Log("Set Gesture = "+CV.key_one);
	}
}
