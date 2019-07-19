using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = Thalmic.Myo.Pose;

public class GestureTracker : MonoBehaviour {
    GameObject myo;
    ThalmicMyo thalmicmyo;
    public string ges_status="";
	// Use this for initialization
	void Start () {
        myo = transform.GetChild(0).gameObject;
        thalmicmyo = myo.GetComponent<ThalmicMyo>();
	}
	
	// Update is called once per frame
	void Update () {
        Fist();
        WaveOut();
        WaveIn();
        Spread();
	}
    void WaveIn() {
        if (thalmicmyo.pose==Pose.WaveIn) {
            ges_status = "WaveIn";
        }
    }
    void WaveOut()
    {
        if (thalmicmyo.pose == Pose.WaveOut)
        {
            ges_status = "WaveOut";
        }
    }
    void Fist() {
        if (thalmicmyo.pose==Pose.Fist) {
            ges_status = "Fist";
        }
    }
    void Spread()
    {
        if (thalmicmyo.pose == Pose.FingersSpread)
        {
            ges_status = "Spread";
        }
    }
}
