using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose=Thalmic.Myo.Pose;

public class GestureManager : MonoBehaviour {

	ThalmicMyo thalmicMyo;
	public GameObject myo;
	// Use this for initialization
	void Start () {
		thalmicMyo=myo.GetComponent<ThalmicMyo>();
	}
	
	// Update is called once per frame
	void Update () {
		Fist();
	}
	void Fist(){
		if(thalmicMyo.pose==Pose.Fist){
			Debug.Log("Fist now");
		}
	}
}
